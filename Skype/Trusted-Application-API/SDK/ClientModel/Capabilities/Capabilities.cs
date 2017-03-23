using System;

namespace Microsoft.SfB.PlatformService.SDK.ClientModel
{
    /// <summary>
    /// Capabilities of an <see cref="AudioVideoFlow"/>, exposed by <see cref="IAudioVideoFlow"/>
    /// </summary>
    public enum AudioVideoFlowCapability
    {
        PlayPrompt = 0
    }

    /// <summary>
    /// Capabilities of a <see cref="Prompt"/>, exposed by <see cref="IPrompt"/>
    /// </summary>
    public enum PromptCapability
    {
    }

    /// <summary>
    /// Capabilities of an <see cref="AudioVideoCall"/>, exposed by <see cref="IAudioVideoCall"/>
    /// </summary>
    public enum AudioVideoCallCapability
    {
        Establish = 0,
        Transfer = 1,
        Terminate = 2
    }

    /// <summary>
    /// Capabilities of a <see cref="MessagingCall"/>, exposed by <see cref="IMessagingCall"/>
    /// </summary>
    public enum MessagingCallCapability
    {
        Establish = 0,
        SendMessage = 1,
        Terminate = 2
    }

    /// <summary>
    /// Capabilities of a <see cref="Transfer"/>, exposed by <see cref="ITransfer"/>
    /// </summary>
    public enum TransferCapability
    {
    }

    /// <summary>
    /// Capabilities of a <see cref="Conversation"/>, exposed by <see cref="IConversation"/>
    /// </summary>
    public enum ConversationCapability
    {
        AddParticipant = 0
    }

    /// <summary>
    /// Capabilities of a <see cref="ConversationConference"/>, exposed by <see cref="IConversationConference"/>
    /// </summary>
    public enum ConversationConferenceCapability
    {
        Terminate = 0
    }

    /// <summary>
    /// Capabilities of a <see cref="ConversationBridge"/>, exposed by <see cref="IConversationBridge"/>
    /// </summary>
    public enum ConversationBridgeCapability
    {
        AddBridgedParticipant = 0
    }

    /// <summary>
    /// Capabilities of <see cref="Participant"/>, exposed by <see cref="IParticipant"/>
    /// </summary>
    internal enum ParticipantsCapability
    {
    }

    /// <summary>
    /// Capabilities of <see cref="BridgedParticipants"/>, exposed by <see cref="IBridgedParticipants"/>
    /// </summary>
    public enum BridgedParticipantsCapability
    {
    }

    /// <summary>
    /// Capabilities of a <see cref="BridgedParticipant"/>, exposed by <see cref="IBridgedParticipant"/>
    /// </summary>
    public enum BridgedParticipantCapability
    {
    }

    /// <summary>
    /// Capabilities of a <see cref="Participant"/>, exposed by <see cref="IParticipant"/>
    /// </summary>
    public enum ParticipantCapability
    {
        Eject = 0
    }

    /// <summary>
    /// Capabilities of a <see cref="ParticipantMessaging"/>, exposed by <see cref="IParticipantMessaging"/>
    /// </summary>
    public enum ParticipantMessagingCapability
    {
    }

    /// <summary>
    /// Capabilities of an <see cref="Application"/>, exposed by <see cref="IApplication"/>
    /// </summary>
    public enum ApplicationCapability
    {
        [Obsolete("Use GetAnonApplicationTokenForMeeting instead")]
        GetAnonApplicationToken = 0,
        [Obsolete("Use CreateAdhocMeeting instead")]
        GetAdhocMeetingResource = 1,
        GetAnonApplicationTokenForMeeting = 2,
        GetAnonApplicationTokenForP2PCall = 3,
        CreateAdhocMeeting = 4
    }

    /// <summary>
    /// Capabilities of an <see cref="AnonymousApplicationToken"/>, exposed by <see cref="IAnonymousApplicationToken"/>
    /// </summary>
    public enum AnonymousApplicationTokenCapability
    {
    }

    /// <summary>
    /// Capabilities of an <see cref="AdhocMeeting"/>, exposed by <see cref="IAdhocMeeting"/>
    /// </summary>
    public enum AdhocMeetingCapability
    {
        JoinAdhocMeeting = 0
    }

    /// <summary>
    /// Capabilities of a <see cref="Communication"/>, exposed by <see cref="ICommunication"/>
    /// </summary>
    public enum CommunicationCapability
    {
        StartMessaging = 0,
        StartMessagingWithIdentity = 1,
        StartAudioVideo = 2,
        StartAudio = 3
    }

    /// <summary>
    /// Capabilities of a <see cref="MessagingInvitation"/>, exposed by <see cref="IMessagingInvitation"/>
    /// </summary>
    public enum MessagingInvitationCapability
    {
        [Obsolete("Use StartMeeting instead")]
        StartAdhocMeeting = 0,
        AcceptAndBridge = 1,
        StartMeeting = 2
    }

    /// <summary>
    /// Capabilities of a <see cref="AudioVideoInvitation"/>, exposed by <see cref="IAudioVideoInvitation"/>
    /// </summary>
    public enum AudioVideoInvitationCapability
    {
        Accept = 0,
        Forward = 1,
        Decline = 2,
        [Obsolete("Use StartMeeting instead")]
        StartAdhocMeeting = 3,
        AcceptAndBridge = 4,
        StartMeeting = 5
    }

    /// <summary>
    /// Capabilities of a <see cref="OnlineMeetingInvitation"/>, exposed by <see cref="IOnlineMeetingInvitation"/>
    /// </summary>
    public enum OnlineMeetingInvitationCapability
    {
    }

    /// <summary>
    /// Capabilities of a <see cref="ParticipantInvitation"/>, exposed by <see cref="IParticipantInvitation"/>
    /// </summary>
    public enum ParticipantInvitationCapability
    {
    }

    /// <summary>
    /// Capabilities of a <see cref="Applications"/>, exposed by <see cref="IApplications"/>
    /// </summary>
    public enum ApplicationsCapability
    {
    }

    /// <summary>
    /// Capabilities of a <see cref="Discover"/>, exposed by <see cref="IDiscover"/>
    /// </summary>
    public enum DiscoverCapability
    {
    }
}
