using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advantys.Workflow.Applications.GSuite
{
    public partial class GSuite
    {
		private static ServiceAccountCredential GetServiceAccountCredential(string[] scopes)
        {
			return new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(ServiceAccountEmail)
                   {
                       Scopes = scopes,
                       ProjectId = ProjectId,
                       User = ImpersonateUser

                   }.FromCertificate(certificate));
        }
    }
}
