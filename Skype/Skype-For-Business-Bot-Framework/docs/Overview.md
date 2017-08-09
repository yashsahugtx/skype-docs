# Skype for Business Bot Framework (Preview)

This article will help you build and enable a Skype for Business bot using the Microsoft Bot Framework.

## Getting Started

**In this section we’ll cover:**
-	[Creating a Skype for Business bot](#create-bot)
-	[Adding a bot to Skype for Business](#add-bot)
-	[Feature Support](#feature-support)
-	[Creating outbound bots](#create-outbound-bots)
-	[Supported Skype for Business versions](#version-suport)
-	[Removing a bot – Developer](#remove-bot-dev)
-	[Removing a bot – Tenant Administrator](#remove-bot-tenant)

<a name="create-bot"></a>
## Creating a Skype for Business bot

The Skype for Business bots are created using the [Microsoft Bot Framework](https://dev.botframework.com/).  Bots created with the framework can easily be configured to work with Skype for Business.  See the [Microsoft Bot Framework Overview](https://docs.botframework.com/en-us/) to learn how to:
1.	Build a bot using the [C# SDK](https://docs.botframework.com/en-us/csharp/builder/sdkreference/), [Node.js SDK](https://docs.botframework.com/en-us/node/builder/chat-reference/modules/_botbuilder_d_.html) or [REST API](https://docs.botframework.com/en-us/restapi/connector/#navtitle).
2.	Test it using the [Bot Framework Emulator](https://docs.botframework.com/en-us/tools/bot-framework-emulator/).
3.	Deploy the bot to a cloud service, such as [Microsoft Azure](https://azure.microsoft.com/en-gb/).
4.	[Register](https://dev.botframework.com/bots/new) the bot with the Microsoft Bot Framework, and click Add Skype for Business as a channel.  Enable the channel in the configuration page.
5.	Add the bot to a Skype for Business tenant by clicking Add to Skype for Business.
 Copy and paste the following code snippet to embed the **Add to Skype for Business** button to your website
  ```html
  <a href='https://skypeappregistration.azurewebsites.net/bot/561bae84-ea1c-4f75-a512-b84566779c2c'><img src='https://dev.botframework.com/ChannelConfigs/Images/skypeforbusiness/Add-To-SkypeForBusiness-Buttons.png'></a>
  ```

  <a href='https://skypeappregistration.azurewebsites.net/bot/561bae84-ea1c-4f75-a512-b84566779c2c'><img src='https://dev.botframework.com/ChannelConfigs/Images/skypeforbusiness/Add-To-SkypeForBusiness-Buttons.png'></a> 


<a name="add-bot"></a>
## Adding a bot to Skype for Business

Bots can only be added to Skype for Business by Tenant Administrators of a Skype for Business Online environment.  By clicking **Add to Skype for Business**, you will launch **[Connecting your bot to Skype for Business Online](https://skypeappregistration.azurewebsites.net/bot/29415286-5a43-4a00-9dc5-bcbc2ce1f59e)** page, which has the instructions for registering your bot. 

The instructions contain the following information:

To add your bot to Skype for Business, you must be the Tenant Administrator of a Skype for Business Online environment. A Tenant Administrator can easily add your bot by using the **[Skype for Business Admin PowerShell cmdlets](https://technet.microsoft.com/en-us/library/dn362831.aspx)**. Please complete the following steps to add a bot:

1. [Download and install the Skype for Business Online Connector module](http://go.microsoft.com/fwlink/?LinkId=294688)
2. Open Windows PowerShell as Administrator and run the following:

  ```PowerShell
   Import-PSSession (New-CsOnlineSession -Credential (Get-Credential))
  ```
3.	You will be prompted with windows PowerShell credential dialog box. Sign in using the tenant admin credentials.

4. Run the following PowerShell cmdlet

```PowerShell
New-CsOnlineApplicationEndpoint -ApplicationID 41ec7d50-ba91-1208-73ee-136b88859725 -Name NameOfTheBot -Uri sip:username@yourdomain.com
```
>Note: For more information see: [Connecting to Skype for Business Online by using Windows PowerShell](https://technet.microsoft.com/en-us/library/dn362795.aspx)
 
This cmdlet registers an instance of your bot with a Skype for Business Online tenant. A Skype for Business Admin can replace the **_Name_** parameter with their desired bot display name and replace the **_Uri_** parameter with a unique user account from their domain (eg. mybot@contoso.com)

>Note: A newly registered bot can take up to 8 hours to be discoverable by all users in the Skype for Business tenant. More details on using PowerShell to manage bots and apps for Skype for Business can be found [here](https://msdn.microsoft.com/en-us/skype/trusted-application-api/docs/trustedapplicationendpoint).

<a name="feature-support"></a>
## Feature Support

- **Messages :**
Your bot can send plain text, HTML, and emoticons to a user or group. Users can send rich text, HTML, and emoticons to your bot.
- **Typing indicator :**
Your bot can send a typing indicator using the [C# SDK](https://docs.botframework.com/en-us/csharp/builder/sdkreference/), [Node.js SDK](https://docs.botframework.com/en-us/node/builder/chat-reference/modules/_botbuilder_d_.html) or [REST API](https://docs.botframework.com/en-us/restapi/connector/#navtitle) to tell the user that the bot is preparing to respond, for example when processing a request.
- **Basic format:**
The Skype for Business ID of a user is available for your bot, and is sent along with the _**display name**_ with every message.

```http 
{
  "type": "message",
  "timestamp": "2017-05-02T18:22:05.4521432Z",
  "serviceUrl": "https://webpoolbl20r02.infra.lync.com/platformservice/tgt-b5eccd26b71c5653a9f3e8faecd568db/botframework",
  "channelId": "skypeforbusiness",
  "from": {
    "id": "sip:user@contoso.com",
    "name": "Contoso User"
  },
  "conversation": {    "isGroup": true,
    "id": "ZmMyYmY4OGMjc2lwOmppZWluY29taW5nYm90ZXA4QDBtY29ycDJjbG91ZHBlcmYub25taWNyb3NvZnQuY2t"
  },
  "recipient": {
    "id": "sip:bot@contoso.com",
    "name": "sip:bot@contoso.com"
  },
  "text": "Hello World",
  "attachments": [],
  "entities": [],
  "replyToId": "2"
}
}
```
  The _**from**_ field contains the unique user Skype for Business identity _**Sip Uri**_ and _**user display name**_.

 The _**to**_ field contains the App Skype for Business identity _**Sip Uri**_ and _**bot display Name**_.
- **Skype for Business emoticons :**
Skype for Business emoticons can be sent by using emoticon keyword.
```http
{
  "text": ":)"
}
```
- **Cards and buttons :**
Skype for Business does not support rendering the cards and buttons . The Cards and buttons sent by a bot will fallback to text in the Skype for Business clients.

- **Groups :**
A bot can be enabled for groups in outgoing bot scenarios.  A bot can message multiple users in a group conversation.  Skype for Business does not support adding an additional participant to a 1:1 bot conversation. 

<a name="create-outbound-bots"></a>
## Creating outbound bots

Skype for Business bots can initiate outbound messages to users proactively because they are enabled by a Tenant Administrator.  In order to initiate an outbound message, your bot must be Skype for Business tenant-specific (your code must be written for a bot that will only be deployed in a single tenant. Eg. bot@contoso.com). 

 In addition, in order to initiate an outbound message, your bot must also have the Skype for Business identity of the user or users that bot will be messaging directly eg. user@contoso.com.
Your bot will also need to add the Skype for Business Channel entry point URL (https://api.skypeforbusiness.com/platformservice/botframework) to the Trusted Service URLs.
Here’s a code snippet that illustrates how to initiate an outbound message to a Skype for Business user using the C# Bot Builder SDK.

```cs
MicrosoftAppCredentials.TrustServiceUrl("https://api.skypeforbusiness.com/platformservice/botframework");     
to = new string[] {"sip:usera@contoso.com", "sip:userb@contoso.com"};
public async Task MakeOutboundCall(string[] to, string topic)
        {
            var connector = new ConnectorClient(new Uri(https://api.skypeforbusiness.com/ platformservice/botframework/)); //initial entry point to talk to the Skype for Business channel
            List<ChannelAccount> participants = new List<ChannelAccount>();
            foreach (string t in to)
            {
                participants.Add(new ChannelAccount(t, t + "name"));
            }
            ConversationParameters cpMessage = new ConversationParameters(true, new ChannelAccount(sip:bot@contoso.com, "DisplayNameofBot"),  participants, topic);
            ConversationResourceResponse  response = await connector.Conversations.CreateConversationAsync(cpMessage);
            ConversationId = response.Id;
            this.UpdateServiceUrl(response.ServiceUrl); //remember response ServiceURL to send additional message requests to the same conversation
        }
```

<a name="version-suport"></a>
## Supported Skype for Business versions

The Skype for Business Bot Framework channel is currently supported for **Skype for Business Online** and **Skype for Business Hybrid enviornment**. 

### **Skype for Business Bot -  Hybrid environment support** 

Skype for Business bots can be connected to Skype for Business Server users if Hybrid connectivity has been deployed in the environment. 

Hybrid connectivity between Skype for Business Server and Skype for Business Online means users of a domain, such as contoso.com, are split between using Skype for Business Server on premises and Skype for Business Online. Some of the domain users are homed on premises, and some users are homed online.  
 
Bots will be configured as online users reachable by the on-premises users.  
#### Getting started 

- For more information about hybrid connectivity, see [Deploy hybrid connectivity between Skype for Business Server and Skype for Business Online](https://technet.microsoft.com/en-us/library/jj204669.aspx). 
- For more information about using Azure AD Connect to configure a hybrid environment, see [Integrate your on-premises directories with Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/connect/active-directory-aadconnect).

#### Setup bot for Skype for Business Hybrid enviornment 

1. Follow [Creating a Skype for Business bot](#create-bot) section to create the bot. 
2. Follow [Adding a bot to Skype for Business](#add-bot) section to add the bot.
3. Sign in as a Tenant administrator of a Skype for Business Online environment and run  the following  PowerShell cmdlet.

```PowerShell
 New-CsOnlineApplicationEndpoint <AppID generated from BotFraework Portal> -Name <NameOfTheBot> -Uri sip:<bothandle>@yourdomain.com

``` 
> Note: For Hybrid OPCH tenants only the above cmdlet will prompt additional commands to be run on the On-Prem server with CU5 patched. 

4. Create an application endpoint on the on-premises server from the Lync Server management Shell using the following on-premises cmdlet.
 
```PowerShell
New-CsHybridApplicationEndpoint -ApplicationId XXX -DisplayName "NameOfTheBot" -SipAddress sip:bot@XXX.com 
```
 |**Parameters**|**Required**|**Type**|**Description**|
|:-----|:-----|:-----|:-----|
|ApplicationId|Required|Guid|The ApplicationId or Client Id for which the endpoint is being created|
|DisplayName|Required|String|Friendly name for the application endpoint|
|SipAddress|Required|String|The SipUri for the Endpoint. SIP Uri must be lowercase.|
|LineUri|Optional|String|Valid phone number for the application endpoint.|
|OU|Optional|String|A valid OU for the application endpoint|
 
The succesful execution of **New-CsHybridApplicationEndpoint** cmdlets will create a disabled user object on the Azure Directory and show **"Successfully initiated provisioning of application endpoint on-prem"** message.

5. Wait for the newly created user object to be DIR syned to the Azure Active Directory or start a new DIR sync cycle by running the Start-ADSyncSyncCycle on the DC machine.

6. Please make sure that you wait for 8 hours before the endpoint is discovered from Skype for Business clients for newly created application ids.  
Onprem user should be able to search for the BOT from the client and initiate chat conversations 


 <a name="remove-bot-dev"></a>
## Removing a bot - Developer
 
- **Deleting a bot :** To delete your bot completely, go to your bot dashboard, select edit the Skype for Business channel and click the Delete button at the bottom.

<a name="remove-bot-tenant"></a>
## Removing a bot – Skype for Business Tenant Administrator
- **Deleting a bot :** To delete a bot completely from a Skype for Business Tenant, you must be the Tenant administrator of a Skype for Business Online environment. A Tenant administrator can easily delete your bot by using the Skype for Business Admin **[PowerShell cmdlets](https://technet.microsoft.com/en-us/library/dn362831.aspx)**. Complete the following steps to delete a bot:

1. [Download and install the Skype for Business Online Connector module](http://go.microsoft.com/fwlink/?LinkId=294688)
2. Open Windows PowerShell as Administrator and run the following:

 ```PowerShell
  Import-PSSession (New-CsOnlineSession -Credential (Get-Credential))
 ```

3.	You will be prompted with windows PowerShell credential dialog box. Sign in using the tenant admin credentials.

4. Run the following PowerShell 

```PowerShell
Remove -CsOnlineApplicationEndpoint -Uri sip:username@yourdomain.com
 ```

>Note: For more information see: [Connecting to Skype for Business Online by using Windows PowerShell]  (https://technet.microsoft.com/en-us/library/dn362795.aspx)

This command removes the instance of a bot with a Skype for Business Online tenant. A Skype for Business Admin must replace the Uri parameter with the user account from their domain (eg. mybot@contoso.com) , which they created when adding the bot.  More details on using PowerShell to manage bots and apps for Skype for Business can be found [here](https://msdn.microsoft.com/en-us/skype/trusted-application-api/docs/trustedapplicationendpoint).

