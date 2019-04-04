using System;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.IO;

namespace Advantys.Workflow.Applications.GSuite
{
    public partial class GSuite
    {
        static string CertificateLocation => ConfigurationManager.AppSettings["GoogleCertificateLocation"];
        static X509Certificate2 certificate => new X509Certificate2(CertificateLocation, "notasecret", X509KeyStorageFlags.MachineKeySet |X509KeyStorageFlags.Exportable);
        static string ServiceAccountEmail => ConfigurationManager.AppSettings["ServiceAccountEmail"];
        static string ProjectId => ConfigurationManager.AppSettings["GSuiteProjectId"];
        static string ImpersonateUser => ConfigurationManager.AppSettings["GSuiteImpersonateUser"];
        static string LogFilePath => ConfigurationManager.AppSettings["GSuiteServiceLogPath"] + DateTime.Now.ToString("dd-MM-yyyy") + "-log.txt";
        const string Success = "ok";

        private static void Log(string message)
        {
            using (StreamWriter streamWriter = System.IO.File.AppendText(LogFilePath))
            {
                streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " - " + message);
            }
        }
    }
}
