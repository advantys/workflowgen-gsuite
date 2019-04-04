# Gmail

- [Send mail](#send-mail)

## Send mail

### Enable Gmail API

1. Go to [**Gmail API**](https://console.cloud.google.com/apis/library/gmail.googleapis.com)
2. Click on **Install**

### Permissions required for your GSuite Apps

1. Go to your GSuite domain’s [Admin console](https://admin.google.com/).

2. Select **Security** from the list of controls. If you don't see **Security** listed, select **More controls** from the gray bar at the bottom of the page, then select **Security** from the list of controls.

3. Select **Advanced settings** from the list of options.

4. Select **Manage API client access** in the **Authentication** section.

5. In the **Client name** field, enter the service account's Client ID.

6. In the **One or More API Scopes field**, enter `https://mail.google.com/,https://www.googleapis.com/auth/gmail.send`

7. Click the **Authorize** button.

### Create the GSUITE_SEND_MAIL application

First, you need to create an application in WorkflowGen with a configuration like the following:

- **Name**: `GSUITE_SEND_MAIL`

- **Description**: `Send mail with GSuite`

- **Type**: `assembly`

- **Assembly full name or path**: `Advantys.Workflow.Applications.GSuite`

- **Class full name**: `Advantys.Workflow.Applications.GSuite.GSuite`

- **Method**: `SendMail`

You can import the following configuration to create the application automatically (make sure your username is included in `ProcessesRuntimeWebServiceAllowedUsers` in the `web.config`).

1. Go to `http://[YOUR_SITE]/wfgen/ws/processesruntime.asmx?op=CreateWorkflowApplication`.

2. Copy and paste the following configuration to `applicationDefinition`:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Application xmlStructureRevisision="1.0">
   <Name>GSUITE_SEND_MAIL</Name>
   <Description>Send mail with GSuite</Description>
   <Type>ASSEMBLY</Type>
   <Method>SendMail</Method>
   <Active>Y</Active>
   <Assembly>Advantys.Workflow.Applications.GSuite</Assembly>
   <Class>Advantys.Workflow.Applications.GSuite.GSuite</Class>
   <Parameters>
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
         <Name>toRecipients</Name>
         <Description>toRecipients</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>ccRecipients</Name>
         <Description>ccRecipients</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>bccRecipients</Name>
         <Description>bccRecipients</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>attachment</Name>
         <Description>attachment</Description>
         <DataType>FILE</DataType>
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
|`subject`|Subject of the email|Required|
|`content`|Content of the email (HTML or text)|Required|
|`toRecipients`|List of principal recipients separated by semicolons (`;`)| Required |
|`ccRecipients`|List of CC recipients separated by semicolons (`;`)| Optional |
|`bccRecipients`|List of BCC recipients separated by semicolons (`;`)| Optional |
|`attachment`|Attachment to send with email|Optional|

### [Example](https://github.com/advantys/workflowgen-gsuite/tree/master/processes/Gmail)

You can use the [`SEND_MAIL_GSUITE`](https://github.com/advantys/workflowgen-gsuite/blob/master/processes/Gmail/SEND_MAIL_GSUITEv1.xml) process as an example.
