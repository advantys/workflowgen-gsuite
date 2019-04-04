# Google Admin

- [Add user](#add-user)

## Add user

### Enable Admin API

1. Go to [**Admin SDK API**](https://console.cloud.google.com/apis/library/admin.googleapis.com)
2. Click on **Install**

### Permissions required for your GSuite apps

1. Go to your GSuite domain’s [Admin console](https://admin.google.com/).

2. Select **Security** from the list of controls. If you don't see **Security** listed, select **More controls** from the gray bar at the bottom of the page, then select **Security** from the list of controls.

3. Select **Advanced settings** from the list of options.

4. Select **Manage API client access** in the **Authentication** section.

5. In the **Client name** field, enter the service account's Client ID.

6. In the **One or More API Scopes field** enter `https://www.googleapis.com/auth/admin.directory.user`

7. Click the **Authorize** button.


### Create the GSUITE_CREATE_USER application

First, you need to create an application in WorkflowGen with a configuration like the following:

- **Name**: `GSUITE_CREATE_USER`

- **Description**: `Create user in GSuite`

- **Type**: `assembly`

- **Assembly full name or path**: `Advantys.Workflow.Applications.GSuite`

- **Class full name**: `Advantys.Workflow.Applications.GSuite.GSuite`

- **Method**: `CreateGSuiteUser`

You can import the following configuration to create the application automatically (make sure your username is included in `ProcessesRuntimeWebServiceAllowedUsers` in the `web.config`).

1. Go to `http://[YOUR_SITE]/wfgen/ws/processesruntime.asmx?op=CreateWorkflowApplication`

2. Copy and paste the following configuration to `applicationDefinition`:

```xml
<Application xmlStructureRevisision="1.0">
    <Name>GSUITE_CREATE_USER</Name>
    <Description>Create user in GSuite</Description>
    <Type>ASSEMBLY</Type>
    <Method>CreateGSuiteUser</Method>
    <Active>Y</Active>
    <Assembly>Advantys.Workflow.Applications.GSuite</Assembly>
    <Class>Advantys.Workflow.Applications.GSuite.GSuite</Class>
    <Parameters>
        <Parameter>
            <Name>lastName</Name>
            <Description>lastName</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>firstName</Name>
            <Description>firstName</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>password</Name>
            <Description>password</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>email</Name>
            <Description>email</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>mobilePhone</Name>
            <Description>mobilePhone</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>country</Name>
            <Description>country</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>city</Name>
            <Description>city</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>department</Name>
            <Description>department</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>postalCode</Name>
            <Description>postalCode</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>jobTitle</Name>
            <Description>jobTitle</Description>
            <DataType>TEXT</DataType>
            <Direction>IN</Direction>
            <Required>Y</Required>
            <Default>N</Default>
        </Parameter>
        <Parameter>
            <Name>officeLocation</Name>
            <Description>officeLocation</Description>
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
| `lastname` | User's lastname | Required |
| `firstname` | User's firstname | Required |
| `password` | User's password, at his first connection he needs to change it (ex P@ssw0rd) | Required |
| `email` | User's email (e.g firstname.lastname@YOUR_DOMAIN.com). Your domain needs to be associate with your office 365 subscription | Required |
| `mobilePhone` | User's mobile phone | Optional |	
| `country` | User's country | Optional |	
| `city` | User's city | Optional |	
| `postalCode` | User's postal code | Optional |	
| `department` | User's department | Optional |	
| `jobTitle` | User's job title | Optional |	
| `officeLocation` | User office's location | Optional |

### [Example]((https://github.com/advantys/workflowgen-gsuite/tree/master/processes/Admin))

You can use the [`CREATE_GSUITE_USER`](https://github.com/advantys/workflowgen-gsuite/blob/master/processes/Admin/CREATE_GSUITE_USER.xml) process as an example.