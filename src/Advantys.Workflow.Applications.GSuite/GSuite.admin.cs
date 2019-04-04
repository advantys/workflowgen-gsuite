using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Google.Apis.Services;
using System;

namespace Advantys.Workflow.Applications.GSuite
{
    public partial class GSuite
    {
        public static string CreateGSuiteUser(string lastName, string firstName, string password, string email,
                                       string mobilePhone, string country, string city, string department,
                                       string postalCode, string jobTitle, string officeLocation)
        {
            // Check parameters
            if (string.IsNullOrEmpty(lastName))
                return "The last name is required";
            if (string.IsNullOrEmpty(firstName))
                return "The first name is required";
            if (string.IsNullOrEmpty(password))
                return "The password is required";
            if (string.IsNullOrEmpty(email))
                return "The email is required";

            try
            {
                User user = new User()
                {
                    Name = new UserName()
                    {
                        FamilyName = lastName,
                        GivenName = firstName,
                        FullName = firstName + " " + lastName
                    },
                    Password = password,
                    PrimaryEmail = email,
                    Phones = new UserPhone[]
                    {
                        new UserPhone()
                        {
                            Value = mobilePhone,
                            Type = "work"
                        }
                    },
                    Addresses = new UserAddress[]
                    {
                        new UserAddress()
                        {
                            Country = country == "" ? null : country,
                            PostalCode = postalCode == "" ? null : postalCode,
                            Locality = city == "" ? null : city
                        }
                    },
                    Organizations = new UserOrganization[]
                    {
                        new UserOrganization()
                        {
                            Title = jobTitle == "" ? null : jobTitle,
                            Location = officeLocation == "" ? null : officeLocation,
                            Department = department == "" ? null : department
                        }
                    }
                };

                string[] scopes = { DirectoryService.Scope.AdminDirectoryUser };

                var service = new DirectoryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = GetServiceAccountCredential(scopes),
                });

                service.Users.Insert(user).ExecuteAsync().Wait();

                return Success;
            }
            catch (Exception e)
            {
                Log("Adding user not possible - Exception : " + e.Message + " InnerException : " + e.InnerException);
                return "Adding user not possible - " + e.Message;
            }

        }
    }
}
