# App Owns Data samples

Read this documentation to prepare your environment
https://docs.microsoft.com/en-us/power-bi/developer/embedding-content

## Choose Auth Method

In web.config:

To embed reports, dashboards and tiles, the following details must be specified within web.config:

| Detail            | Description                                                                                           |
|-------------------|-------------------------------------------------------------------------------------------------------|
| applicationId     | Id of the AAD application registered as a NATIVE app.                                                 |
| workspaceId       | The group or workspace Id in Power BI containing the reports, dashboards and tiles you want to embed. |
| pbiUsername       | A Power BI username (e.g. Email). The user must be an admin of the group above. (For Master User Only)|
| pbiPassword       | The password of the Power BI user above. (For Master User Only)                                       |

The specific reports and dashboards are separate entries in the web.config. Each of these will also need a Controller function and View.

## Update nuget packages

In Visual Studio 2019, may get this error: Could not find a part of the path ...bin\roslyn\csc.exe

Error is fixed by updating the following in Package Manger Console: Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r

## KeyVault to hold app secrets

Azure KeyVault will be used to hold the Power BI Pro username and password.

Configured KeyVault as a Connected Service: https://docs.microsoft.com/en-us/azure/key-vault/vs-key-vault-add-connected-service
	Make sure the ASP.NET Target Framework is 4.7.1 or greater for KeyVault configurations to properly update the web.config file
	Not referenced in the help guide, update appSettings in web.config: <appSettings configBuilders="AzureKeyVault">

Configure the app to use a Managed Service Identity: https://docs.microsoft.com/en-us/azure/key-vault/tutorial-net-create-vault-azure-web-app#managed-service-identity-and-how-it-works