using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advantys.Workflow.Applications.GSuite
{
    public partial class GSuite
    {
        public static string ScheduleMeeting(string attendees, string subject, string content,
                                            string location, string startDate, string startTime,
                                            string endDate, string endTime, string dateFormat,
                                            string timeFormat, string culture, string wfgTimeZone)
        {
            //Check parameters
            if (string.IsNullOrEmpty(attendees))
                return "Attendees are required";
            if (string.IsNullOrEmpty(subject))
                return "The subject is required";
            if (string.IsNullOrEmpty(startDate))
                return "The start date is required";
            if (string.IsNullOrEmpty(startTime))
                return "The start time is required";
            if (string.IsNullOrEmpty(endDate))
                return "The end date is required";
            if (string.IsNullOrEmpty(endTime))
                return "The end time is required";
            if (string.IsNullOrEmpty(dateFormat))
                return "The date format is required";
            if (string.IsNullOrEmpty(timeFormat))
                return "The time format is required";
            if (string.IsNullOrEmpty(culture))
                return "The culture is required";
            if (string.IsNullOrEmpty(wfgTimeZone))
                return "The WorkflowGen timezone is required";

            try
            {
                //Delete specific characters form WFG's time zone to conform to TimeZoneCustom.resx
                wfgTimeZone = wfgTimeZone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(":", "")
                        .Replace(" ", "").Replace(",", "").Replace(".", "").Replace("'", "");
                string timeZoneCustom = TimeZoneCustom.ResourceManager.GetString(wfgTimeZone);

                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(culture);

                DateTime start = DateTime.ParseExact(startDate + " " + startTime, dateFormat + " " + timeFormat,
                                           cultureInfo);

                DateTime end = DateTime.ParseExact(endDate + " " + endTime, dateFormat + " " + timeFormat,
                                           cultureInfo);


                Event newEvent = new Event()
                {
                    Summary = subject,
                    Location = location,
                    Description = content,
                    Start = new EventDateTime()
                    {
                        DateTime = start,
                        TimeZone = timeZoneCustom,
                    },
                    End = new EventDateTime()
                    {
                        DateTime = end,
                        TimeZone = timeZoneCustom,
                    },
                    Reminders = new Event.RemindersData()
                    {
                        UseDefault = true
                    },

                    
                };

                List<EventAttendee> attendeesLst = new List<EventAttendee>();
                foreach (var attendee in attendees.Split(';'))
                {
                    attendeesLst.Add(new EventAttendee() { Email = attendee });
                }
                newEvent.Attendees = attendeesLst;

                // Creation preparation
                string[] scopes = { CalendarService.Scope.CalendarEvents };

                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = GetServiceAccountCredential(scopes),
                });

                string calendarId = "primary";
                EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
                request.SendUpdates = EventsResource.InsertRequest.SendUpdatesEnum.All;
                Event createdEvent = request.Execute();

                return Success;
            }
            catch (Exception e)
            {
                Log("[ScheduleMeeting] Error - We could not create event " + e.Message + " - InnerException : " + e.InnerException);
                return "We could not create event " + e.Message;
            }
        }
    }
}
