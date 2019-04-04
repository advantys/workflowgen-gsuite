# OneDrive

- [Upload a file](#upload-a-file)

## Upload a file

### Enable Google Drive API

1. Go to [**Google Drive API**](https://console.cloud.google.com/apis/library/drive.googleapis.com)
2. Click on **Install**

### Permissions required for your GSuite Apps

1. Go to your GSuite domain’s [Admin console](https://admin.google.com/).

2. Select **Security** from the list of controls. If you don't see **Security** listed, select **More controls** from the gray bar at the bottom of the page, then select **Security** from the list of controls.

3. Select **Advanced settings** from the list of options.

4. Select **Manage API client access** in the **Authentication** section.

5. In the **Client name** field, enter the service account's Client ID.

6. In the **One or More API Scopes field**, enter `https://www.googleapis.com/auth/drive.file`

7. Click the **Authorize** button.

### Create the GSUITE_UPLOAD_FILE_DRIVE application

First, you need to create an application in WorkflowGen with a configuration like the following:

- **Name**: `GSUITE_UPLOAD_FILE_DRIVE`

- **Description**: `Upload file to Drive folder`

- **Type**: `assembly`

- **Assembly full name or path**: `Advantys.Workflow.Applications.GSuite`

- **Class full name**: `Advantys.Workflow.Applications.GSuite.GSuite`

- **Method**: `UploadFileDrive`

You can import the following configuration to create the application automatically (make sure your username is included in `ProcessesRuntimeWebServiceAllowedUsers` in the `web.config` file).

1. Go to `http://[YOUR_SITE]/wfgen/ws/processesruntime.asmx?op=CreateWorkflowApplication`.

2. Copy and paste the following configuration to `applicationDefinition`:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Application xmlStructureRevisision="1.0">
   <Name>GSUITE_UPLOAD_FILE_DRIVE</Name>
   <Description>Upload file to Drive folder</Description>
   <Type>ASSEMBLY</Type>
   <Method>UploadFileDrive</Method>
   <Active>Y</Active>
   <Assembly>Advantys.Workflow.Applications.GSuite</Assembly>
   <Class>Advantys.Workflow.Applications.GSuite.GSuite</Class>
   <Parameters>
      <Parameter>
         <Name>folderId</Name>
         <Description>folderId</Description>
         <DataType>TEXT</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>requestNumber</Name>
         <Description>requestNumber</Description>
         <DataType>NUMERIC</DataType>
         <Direction>IN</Direction>
         <Required>Y</Required>
         <Default>N</Default>
      </Parameter>
      <Parameter>
         <Name>file</Name>
         <Description>file</Description>
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
|`file`|File to upload | Required|
|`folderId`|Destination folder ID|Required|
|`requestNumber`|Request number (`CURRENT_REQUEST`)| Required |

### [Example](https://github.com/advantys/workflowgen-gsuite/tree/master/processes/Drive)

You can use the [`ARCHIVING_FILE_DRIVE`](https://github.com/advantys/workflowgen-gsuite/blob/master/processes/Drive/ARCHIVING_FILE_DRIVEv1.xml) process as an example. You'll need to use the [`BU_GSUITE`](https://github.com/advantys/workflowgen-gsuite/blob/develop/processes/Drive/BU_GSUITE.xml) global list and create various teamdrive and folders in your Drive.

In our example, we have three Business Units represented by TeamDrive in Google Drive; in each Business Unit, we have three domains represented by folders.

```
|-- Aerospace
    |-- Aviation
    |-- Defense
    |-- Space
|-- Telecom
    |-- IoT
    |-- Metering
    |-- Telecom
|-- Transport
    |-- Marine
    |-- Racing
    |-- Rail
```

If you want to use the process example, perform the following steps:

1. Go to Google Drive.

2. Create a Team Drive (https://drive.google.com/drive/u/2/team-drives)

3. Create folders in your TeamDrive.

4. In the `BU_GSUITE` global list, update the `IdDomainFolder` columns.

5. To get `IdDomainFolder`, go to your folder and copy id from the URL. Paste to the `IdDomainFolder` column

6. Add the user service account as a member with `Contributor` role