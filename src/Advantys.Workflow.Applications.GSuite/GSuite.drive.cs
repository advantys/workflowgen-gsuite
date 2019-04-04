using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using WorkflowGen.My.Data;
using File = Google.Apis.Drive.v3.Data.File;

namespace Advantys.Workflow.Applications.GSuite
{
    public partial class GSuite
    {
        public static string UploadFileDrive(string folderId, double requestNumber, WorkflowFile file)
        {
            // Check parameters
            if (string.IsNullOrEmpty(folderId))
                return "The folder id is required";
            if (string.IsNullOrEmpty(requestNumber.ToString()))
                return "The request number is required";
            if (file == null)
                return "The file is required";

            try
            {
                File body = new File();
                body.Name = requestNumber + "_" + file.Name;
                body.Description = file.Name;
                body.MimeType = file.ContentType;
                body.Parents = new List<string> { folderId };
                Stream stream = new MemoryStream(file.Content);

                // Insert preparation
                string[] scopes = { DriveService.Scope.DriveFile };

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = GetServiceAccountCredential(scopes),
                });

                FilesResource.CreateMediaUpload request = service.Files.Create(body, stream, file.ContentType);
                request.SupportsTeamDrives = true;
                request.UploadAsync().Wait();

                return Success;
            }
            catch (Exception e)
            {
                Log("[UploadFileDrive] Error - " + e.Message + " - InnerException : " + e.InnerException);
                return "[UploadFileDrive] Error - " + e.Message;
            }

        }
    }
}
