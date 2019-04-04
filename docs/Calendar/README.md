# Google Calendar

- [Create an event](#create-an-event)

## Create an event

### Enable Google Calendar API

1. Go to [**Google Calendar API**](https://console.cloud.google.com/apis/library/calendar-json.googleapis.com)
2. Click on **Install**

### Permissions required for your GSuite Apps

1. Go to your GSuite domain’s [Admin console](https://admin.google.com/).

2. Select **Security** from the list of controls. If you don't see **Security** listed, select **More controls** from the gray bar at the bottom of the page, then select **Security** from the list of controls.

3. Select **Advanced settings** from the list of options.

4. Select **Manage API client access** in the **Authentication** section.

5. In the **Client name** field, enter the service account's Client ID.

6. In the **One or More API Scopes field**, enter `https://www.googleapis.com/auth/calendar.events`.

7. Click the **Authorize** button.

### Create the GSUITE_SCHEDULE_MEETING application

First, you need to create an application in WorkflowGen with a configuration like the following:

- **Name**: `GSUITE_SCHEDULE_MEETING`

- **Description**: `Create an event with GSuite`

- **Type**: `assembly`

- **Assembly full name or path**: `Advantys.Workflow.Applications.GSuite`

- **Class full name**: `Advantys.Workflow.Applications.GSuite.GSuite`

- **Method**: `ScheduleMeeting`

You can import the following configuration to create the application automatically (make sure your username is included in `ProcessesRuntimeWebServiceAllowedUsers` in the `web.config`).

1. Go to `http://[YOUR_SITE]/wfgen/ws/processesruntime.asmx?op=CreateWorkflowApplication`

2. Copy and paste the following configuration to `applicationDefinition`:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Application xmlStructureRevisision="1.0">
   <Name>GSUITE_SCHEDULE_MEETING</Name>
   <Description>Create an event with GSuite</Description>
   <Type>ASSEMBLY</Type>
   <Method>ScheduleMeeting</Method>
   <Active>Y</Active>
   <Assembly>Advantys.Workflow.Applications.GSuite</Assembly>
   <Class>Advantys.Workflow.Applications.GSuite.GSuite</Class>
   <Parameters>
      <Parameter>
         <Name>attendees</Name>
         <Description>attendees</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>subject</Name>
         <Description>subject</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>content</Name>
         <Description>content</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>location</Name>
         <Description>location</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>startDate</Name>
         <Description>startDate</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>startTime</Name>
         <Description>startTime</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>endDate</Name>
         <Description>endDate</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>endTime</Name>
         <Description>endTime</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>dateFormat</Name>
         <Description>dateFormat</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>timeFormat</Name>
         <Description>timeFormat</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>culture</Name>
         <Description>culture</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>wfgTimeZone</Name>
         <Description>wfgTimeZone</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>RETURN_VALUE</Name>
         <Description>RETURN_VALUE</Description>
         <DataType>TEXT</DataType>
         <Direction>OUT</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
   </Parameters>
</Application>
```

### Parameters

| Name | Description | Type |
| --- | --- |---|
| `attendees` | Attendees at the meeting | Required |
| `subject` | Subject of the meeting | Required |
| `content` | Content of the meeting | Optional |
| `location` | Location of the meeting | Optional |
| `startDate` | Start date of the meeting (e.g. `01-09-2018`) | Required |
| `endDate` | End date of the meeting (e.g. `01-09-2018`) | Required |
| `startTime` | Start time of the meeting (e.g. `10:00`) | Required |
| `endTime` | End time of the meeting (e.g. `11:00`) | Required |
| `dateFormat` | Date format, which needs to correspond to `startDate` and `endDate` (e.g. `dd-MM-yyyy`) | Required |
| `timeFormat` | Time format, which needs to correspond to `startTime` and `endTime` (e.g. `HH:mm`) | Required |
| `culture` | Culture used by the current user; you can get this value using the `System.Language` macro | Required |
| `wfgTimeZone` | Current user's time zone; you need to add code in your form | Required |

#### Get current user time zone

The code bellow permits to get the current user time zone, you can use the returned value for `wfgTimeZone` parameter.

1. Add a read-only field to the form (e.g. the current time zone with `TIMEZONE` ID).

2. Add the following code in code-behind:

```csharp
protected void Page_Load(object sender, EventArgs e)
{
    base.Page_Load(sender, e);
    GetCurrentTimeZone();
}

private void GetCurrentTimeZone()
{
    WorkflowGen.My.Globalization.TimeZoneInformation tz = new WorkflowGen.My.Globalization.TimeZoneInformation(this.CurrentTimeZoneInfo);
    REQUEST_TIME_ZONE.Text = tz.DisplayName;
}
```

### [Example](https://github.com/advantys/workflowgen-gsuite/tree/master/processes/Calendar)

You can use the [`SCHEDULE_MEETING_GSUITE`](https://github.com/advantys/workflowgen-gsuite/blob/master/processes/Calendar/SCHEDULE_MEETING_GSUITEv1.xml) process as an example.
