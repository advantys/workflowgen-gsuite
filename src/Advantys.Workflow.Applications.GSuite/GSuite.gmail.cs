using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using MimeKit;
using System;
using System.IO;
using System.Net.Mail;
using WorkflowGen.My.Data;

namespace Advantys.Workflow.Applications.GSuite
{
    public partial class GSuite
    {
        public static string SendMail(string subject, string content, string toRecipients,
                                          string ccRecipients, string bccRecipients,
                                          WorkflowFile attachment)
        {
            // Check parameters
            if (string.IsNullOrEmpty(subject))
                return "The subject is required";
            if (string.IsNullOrEmpty(content))
                return "The content is required";
            if (string.IsNullOrEmpty(toRecipients))
                return "Recipients are required";

            try
            {
                // Prepare the recipient list
                string[] splitter = { ";" };
                var splitToRecipientsString = toRecipients.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                var splitCcRecipientsString = ccRecipients.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                var splitBccRecipientsString = bccRecipients.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                // Message construction
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(ImpersonateUser);
                mailMessage.ReplyToList.Add(ImpersonateUser);
                mailMessage.Subject = subject;
                mailMessage.Body = content;
                mailMessage.IsBodyHtml = true;

                foreach (string recipient in splitToRecipientsString)
                {
                    mailMessage.To.Add(recipient);
                }
                foreach (string recipient in splitCcRecipientsString)
                {
                    mailMessage.CC.Add(recipient);
                }
                foreach (string recipient in splitBccRecipientsString)
                {
                    mailMessage.Bcc.Add(recipient);
                }
                if (attachment != null)
                {
                    Stream stream = new MemoryStream(attachment.Content);
                    mailMessage.Attachments.Add(new Attachment(stream, attachment.Name));
                }

                var mimeMessage = MimeMessage.CreateFromMailMessage(mailMessage);

                var gmailMessage = new Message
                {
                    Raw = Encode(mimeMessage.ToString())
                };

                // Sending preparation
                string[] scopes = { GmailService.Scope.GmailSend };

                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = GetServiceAccountCredential(scopes),
                });

                service.Users.Messages.Send(gmailMessage, ImpersonateUser).ExecuteAsync().Wait();

                return Success;

            }
            catch (Exception e)
            {
                Log("[SendMail] Error - We could not send the message: " + e.Message + " - InnerException : " + e.InnerException );
                return "We could not send the message: " + e.Message;
            }

        }

        /*
          standard  | 62 | 63 | pad
          -------------------------
          base64    | +  | /  | =
          base64Url | -  | _  | N/A
        */
        private static string Encode(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

            return System.Convert.ToBase64String(bytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }
    }
}
