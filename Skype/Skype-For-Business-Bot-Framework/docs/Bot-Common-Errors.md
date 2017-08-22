# Skype for Business Bot - Common Errors
The most common error codes encountered are outlined in the following tables.
## New-CsOnlineApplicationEndpoint common errors
|Error|Resolution|
|:-|:-|
|**+ FullyQualifiedErrorId : Error processing cmdlet request**<br> "type":"Microsoft.Skype.EnterpriseVoice.CbdService.DataAccess.EntityNotFoundException"|Add a Url for CallbackUri in the messaging Url field in botframework properties|
|**+ FullyQualifiedErrorId : Could not get application endpoint or the Uri is already present as an User in BVD**|Delete the existing user account with the same sipuri in tenant or run the cmdlet using a sipuri that does not already exist in tenant|
|**+ FullyQualifiedErrorId : Error processing cmdlet request**<br> "message":"Validation failed on entity"<br> "type":"System.ArgumentException" <br>"message":"SipUri cannot be NULL or Empty and it has be lowercase" <br>"type":"System.ComponentModel.DataAnnotations.ValidationException"|Commonly seen when -Uri has uppercase characters. Use lowercase for -Uri parameter|
|**+ FullyQualifiedErrorId : Error processing cmdlet request**<br>"type":"Microsoft.Rtc.Management.Hosted.PlatformService.ProvisioningLibrary.ApplicationEndpointProvisioningException was thrown."|Timing issues in provisioning? Error sometimes also seen with ‘Set-* -Uri’, although issue resolves itself after a few minutes.<br>Run Set-CsOnlineApplicationEndpoint -Uri  <app@domain.com> followed by Get-CsOnlineApplication -Uri <app@domain.com> to verify there are no issues.|
|**+ FullyQualifiedErrorId : Error processing cmdlet**<br>**+ FullyQualifiedErrorId : {"odata.error":{"code":"Request_BadRequest","message":{"lang":"en","value":"Property immutableId is invalid."}**|Result of running cmdlet on a hybrid topology with a federated domain. Workaround is to use a non-federated domain.|
|Processing data from remote server failed with the following error message: The user 'victor@metio.onmicrosoft.com' does not have permission to manage this tenant.|Make sure you are sign-in as a Tenant Admin, see [About the Skype for Business admin role](https://support.office.com/en-us/article/About-the-Skype-for-Business-admin-role-aeb35bda-93fc-49b1-ac2c-c74fbeb737b5) for details.|
|||

 ## Other common errors

|Error|Resolution|
|:-|:-|
|There was an error sending the message to your bot. HTTP status code Gateway Timeout|SFB can only callback to 443 port for external urls. SFB does not allow other ports for security reasons.|
 

 
 
 
 
 
 
 
 
 