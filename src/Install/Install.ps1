function LaunchGSuiteDownload
{
    $url = "https://dist.nuget.org/win-x86-commandline/v4.8.1/nuget.exe"
    $output = "$PSScriptRoot\nuget.exe"
    $workingFolder = "$PSScriptRoot\workingFolder"
    $webPath = $settings.WebAppPath
    $servicePath = $settings.ServicesPath


    Invoke-WebRequest -Uri $url -OutFile $output


    #Get Google APIs amd google auth Package
    
    $command = "$PSScriptRoot\nuget.exe install Google.Apis.Auth -Version 1.37.0 -OutputDirectory $workingFolder"

    iex $command

    Copy-Item "$workingFolder\Google.Apis.1.37.0\lib\net45\Google.Apis.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\Google.Apis.1.37.0\lib\net45\Google.Apis.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\Google.Apis.1.37.0\lib\net45\Google.Apis.dll" -Destination "$servicePath\bin"

    Copy-Item "$workingFolder\Google.Apis.1.37.0\lib\net45\Google.Apis.PlatformServices.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\Google.Apis.1.37.0\lib\net45\Google.Apis.PlatformServices.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\Google.Apis.1.37.0\lib\net45\Google.Apis.PlatformServices.dll" -Destination "$servicePath\bin"

    Copy-Item "$workingFolder\Google.Apis.Core.1.37.0\lib\net45\Google.Apis.Core.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\Google.Apis.Core.1.37.0\lib\net45\Google.Apis.Core.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\Google.Apis.Core.1.37.0\lib\net45\Google.Apis.Core.dll" -Destination "$servicePath\bin"

    #Set Newtonsoft.Json 10.0 in GAC
    $dllpath = "$workingFolder\Newtonsoft.Json.10.0.2\lib\net45\Newtonsoft.Json.dll"
    [System.Reflection.Assembly]::Load("System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")            
    $publish = New-Object System.EnterpriseServices.Internal.Publish            
    $publish.GacInstall($dllpath)    

    Copy-Item "$workingFolder\Google.Apis.Auth.1.37.0\lib\net45\Google.Apis.Auth.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\Google.Apis.Auth.1.37.0\lib\net45\Google.Apis.Auth.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\Google.Apis.Auth.1.37.0\lib\net45\Google.Apis.Auth.dll" -Destination "$servicePath\bin"

    Copy-Item "$workingFolder\Google.Apis.Auth.1.37.0\lib\net45\Google.Apis.Auth.PlatformServices.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\Google.Apis.Auth.1.37.0\lib\net45\Google.Apis.Auth.PlatformServices.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\Google.Apis.Auth.1.37.0\lib\net45\Google.Apis.Auth.PlatformServices.dll" -Destination "$servicePath\bin"
    
    #Get Gmail API Package
    $command = "$PSScriptRoot\nuget.exe install Google.Apis.Gmail.v1 -Version 1.37.0.1431 -DependencyVersion Ignore -OutputDirectory $workingFolder"

    iex $command

    Copy-Item "$workingFolder\Google.Apis.Gmail.v1.1.37.0.1431\lib\net45\Google.Apis.Gmail.v1.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\Google.Apis.Gmail.v1.1.37.0.1431\lib\net45\Google.Apis.Gmail.v1.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\Google.Apis.Gmail.v1.1.37.0.1431\lib\net45\Google.Apis.Gmail.v1.dll" -Destination "$servicePath\bin"
    
    #Get Calendar API Package
    $command = "$PSScriptRoot\nuget.exe install Google.Apis.Calendar.v3 -Version 1.37.0.1461 -DependencyVersion Ignore -OutputDirectory $workingFolder"

    iex $command

    Copy-Item "$workingFolder\Google.Apis.Calendar.v3.1.37.0.1461\lib\net45\Google.Apis.Calendar.v3.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\Google.Apis.Calendar.v3.1.37.0.1461\lib\net45\Google.Apis.Calendar.v3.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\Google.Apis.Calendar.v3.1.37.0.1461\lib\net45\Google.Apis.Calendar.v3.dll" -Destination "$servicePath\bin"
    
    #Get Drive API Package
    $command = "$PSScriptRoot\nuget.exe install Google.Apis.Drive.v3 -Version 1.37.0.1466 -DependencyVersion Ignore -OutputDirectory $workingFolder"

    iex $command

    Copy-Item "$workingFolder\Google.Apis.Drive.v3.1.37.0.1466\lib\net45\Google.Apis.Drive.v3.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\Google.Apis.Drive.v3.1.37.0.1466\lib\net45\Google.Apis.Drive.v3.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\Google.Apis.Drive.v3.1.37.0.1466\lib\net45\Google.Apis.Drive.v3.dll" -Destination "$servicePath\bin"

    #Get Admin API Package
    $command = "$PSScriptRoot\nuget.exe install Google.Apis.Admin.Directory.directory_v1 -Version 1.37.0.1355 -DependencyVersion Ignore -OutputDirectory $workingFolder"

    iex $command

    Copy-Item "$workingFolder\Google.Apis.Admin.Directory.directory_v1.1.37.0.1355\lib\net45\Google.Apis.Admin.Directory.directory_v1.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\Google.Apis.Admin.Directory.directory_v1.1.37.0.1355\lib\net45\Google.Apis.Admin.Directory.directory_v1.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\Google.Apis.Admin.Directory.directory_v1.1.37.0.1355\lib\net45\Google.Apis.Admin.Directory.directory_v1.dll" -Destination "$servicePath\bin"

   #Get MimeKit API
    $command = "$PSScriptRoot\nuget.exe install MimeKit -Version 2.1.0 -OutputDirectory $workingFolder"

    iex $command

    Copy-Item "$workingFolder\MimeKit.2.1.0\lib\net45\MimeKit.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\MimeKit.2.1.0\lib\net45\MimeKit.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\MimeKit.2.1.0\lib\net45\MimeKit.dll" -Destination "$servicePath\bin"

    Copy-Item "$workingFolder\BouncyCastle.1.8.2\lib\BouncyCastle.Crypto.dll" -Destination "$webPath\bin"
    Copy-Item "$workingFolder\BouncyCastle.1.8.2\lib\BouncyCastle.Crypto.dll" -Destination "$webPath\ws\bin"
    Copy-Item "$workingFolder\BouncyCastle.1.8.2\lib\BouncyCastle.Crypto.dll" -Destination "$servicePath\bin"
    
    Remove-Item $output
    Remove-Item $workingFolder -Force -Recurse
    
}



if (Test-Path "$PSScriptRoot\config.json"){
  $settings = (Get-Content "$PSScriptRoot\config.json" -Raw) | ConvertFrom-Json
}
else{
  Write-Host "The configuration file config.json was not found in the present working directory."
}

#Checking parameter validity
Write-Host $settings.WebAppPath

if($settings.WebAppPath -eq $null -Or $settings.WebAppPath -eq ""){
    $message = "Please specify a 'WebAppPath' parameter."
    Write-Host $message
    exit 1
}
if($settings.ServicesPath -eq $null -Or $settings.ServicesPath -eq ""){
    $message = "Please specify a 'ServicesPath' parameter in config.json."
    Write-Host $message
    exit 1
}

if(Test-Path $settings.WebAppPath)
{
    $message = "WebAppPath valid"
    Write-Host $message

    if(Test-Path $settings.ServicesPath)
    {
        $message = "ServicesPath valid"
        Write-Host $message
        LaunchGSuiteDownload

        #Copy WorkflowGenGsuite dll
        Copy-Item "$PSScriptRoot\Advantys.Workflow.Applications.GSuite.dll" -Destination "$webPath\bin"
        Copy-Item "$PSScriptRoot\Advantys.Workflow.Applications.GSuite.dll" -Destination "$webPath\ws\bin"
        Copy-Item "$PSScriptRoot\Advantys.Workflow.Applications.GSuite.dll" -Destination "$servicePath\bin"

    }
    else
    {
        $message = "ServicesPath not valid, folder not found. Please correct it in config.json"
        Write-Host $message
        exit 1
    }
}
else
{
    $message = "WebAppPath not valid, folder not found. Please correct it in config.json"
    Write-Host $message
    exit 1
}

