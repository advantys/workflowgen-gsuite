# WorkflowGen and Google GSuite Integration Samples

## Overview

This repository includes the `Advantys.Workflow.Applications.GSuite.dll` assembly and the associated Visual Studio project.
This assembly exposes multiple methods that can be used as WorkflowGen applications for each integration feature.

## Contents

* `docs`: Workflow applications documentation

* `processes`: Process definition file examples

* `src`: Visual Studio solution

## Prerequisites

* GSuite subscription

* Access to GSuite admin panel: https://admin.google.com/

* A user service account with GSuite email (such as `workflowgen@YOUR_DOMAIN.com`)

* `Workflowgen.My.dll` 4.2.0+ and WorkflowGen Server version 7.10.0 or later

## Installation

### Application registration

Create a project in Google Developers Console (https://console.developers.google.com) with an admin account.

#### Create a service account

1. Go to https://console.developers.google.com/projectselector/iam-admin/serviceaccounts.

2. Click **Create service account**.

3. In the first window, set a name and description

4. In the second window, set the account as the `owner` of the project.

5. In the last window, click **Create a key** and select `p12` as the key type.

6. Save the `p12` file as `key.p12`.

### Libraries installation on the WorkflowGen Server

The following components will be installed in the WorkflowGen `\bin` folders (`\wfgen\bin`, `\wfgen\ws\bin`, `..\Program Files\Advantys\WorkflowGen\Service\bin`):

* `Advantys.Workflow.Applications.GSuite.dll` 
* `Google.Apis.Auth v1.37.0`
* `Google.Apis.Gmail.v1 v1.37.0.1431`
* `Google.Apis.Calendar.v3 v1.37.0.1461`
* `Google.Apis.Drive.v3 v1.37.0.1466`
* `Google.Apis.Admin.Directory.directory_v1 v1.37.0.1355`
* `MimeKit v2.1.0`
* `BouncyCastle.1.8.2`

The `Newtonsoft.Json 10.0` librarie will be installed in the GAC.

#### Quick Start

1. Download the [latest release pack](https://github.com/advantys/workflowgen-gsuite/releases) to your WorkflowGen server.

2. Edit the `config.json` file, replacing `WebAppPath` and `ServiceAppPath` with your own paths (the default values are already specified).

3. Execute the `Install.ps1` script in PowerShell in Administrator mode. 

#### Custom installation

1. Clone the repository.

2. Open the `WorkflowGenGSuite.sln` Visual Studio solution.

3. Compile the solution and copy the generated `Advantys.Workflow.Applications.GSuite.dll` file to the `src/Install` folder.

4. Edit the `config.json`, replacing `WebAppPath` and `ServiceAppPath` with your own paths (the default values are already specified).

5. Execute the `Install.ps1` script in PowerShell. 
 
### WorkflowGen configuration

Add the following settings to the WorkflowGen `\wfgen\web.config` with your own values:

```xml
<add key="ServiceAccountEmail" value="SERVICE_ACCOUNT_EMAIL" />
<add key="GSuiteProjectId" value="PROJECT_NAME" />
<add key="GSuiteImpersonateUser" value="USER_EMAIL" />
<add key="GoogleCertificateLocation" value="P12_LOCATION" />
<add key="GSuiteServiceLogPath" value="LOG_PATH" />
```

* **`SERVICE_ACCOUNT_EMAIL`**: Email of the service you created earlier.

* **`PROJECT_NAME`**: Name of your project.

* **`USER_EMAIL`**: Your user service account with GSuite email (e.g `workflowgen@YOUR_DOMAIN.com`).

* **`P12_LOCATION`**: Path to your `key.p12` file.

* **`LOG_PATH`**: The path where the logs will be saved.

## Workflow applications installation

Now that the required components are installed, you can deploy WorkflowGen applications for each integration.

### [Gmail](https://github.com/advantys/workflowgen-gsuite/tree/master/docs/Gmail)

* Send mail 

### [Google Calendar](https://github.com/advantys/workflowgen-gsuite/tree/master/docs/Calendar)

* Create an event

### [Google Drive](https://github.com/advantys/workflowgen-gsuite/tree/master/docs/Drive)

* Upload a file

### [Google Admin](https://github.com/advantys/workflowgen-gsuite/tree/master/docs/Admin)

* Add an user