using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Microsoft.SfB.PlatformService.SDK.Common
{
    /// <summary>
    /// Represents the SipUri.
    /// </summary>
    /// <seealso cref="System.Uri" />
    [Serializable]
    public class SipUri : Uri
    {
        /// <summary>
        /// Gets the domain.
        /// </summary>
        /// <value>The domain.</value>
        public string Domain
        {
            get { return ToString().Split('@')[1]; }
        }

        private static readonly Regex EmailRegex = new Regex(Constants.EmailRegex, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        /// <summary>
        /// Initializes a new instance of the <see cref="SipUri"/> class.
        /// </summary>
        /// <param name="uriString">A URI.</param>
        public SipUri(string uriString) : base(uriString)
        {
            Initialize();
        }

#pragma warning disable CS0618 // Type or member is obsolete
        /// <summary>
        /// Initializes a new instance of the <see cref="SipUri"/> class.
        /// </summary>
        /// <param name="uriString">The URI.</param>
        /// <param name="dontEscape">true if <paramref name="uriString" /> is completely escaped; otherwise, false. See Remarks.</param>
        public SipUri(string uriString, bool dontEscape) : base(uriString, dontEscape)
        #pragma warning restore CS0618 // Type or member is obsolete
        {
            Initialize();
        }

#pragma warning disable CS0618 // Type or member is obsolete
        /// <summary>
        /// Initializes a new instance of the <see cref="SipUri"/> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="relativeUri">The relative URI to add to the base URI.</param>
        /// <param name="dontEscape">true if <paramref name="uriString" /> is completely escaped; otherwise, false. See Remarks.</param>
        public SipUri(Uri baseUri, string relativeUri, bool dontEscape) : base(baseUri, relativeUri, dontEscape)
        #pragma warning restore CS0618 // Type or member is obsolete
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SipUri"/> class.
        /// </summary>
        /// <param name="uriString">A string that identifies the resource to be represented by the <see cref="T:System.Uri" /> instance.</param>
        /// <param name="uriKind">Specifies whether the URI string is a relative URI, absolute URI, or is indeterminate.</param>
        public SipUri(string uriString, UriKind uriKind) : base(uriString, uriKind)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SipUri"/> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="relativeUri">The relative URI to add to the base URI.</param>
        public SipUri(Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SipUri"/> class.
        /// </summary>
        /// <param name="baseUri">An absolute <see cref="T:System.Uri" /> that is the base for the new <see cref="T:System.Uri" /> instance.</param>
        /// <param name="relativeUri">A relative <see cref="T:System.Uri" /> instance that is combined with <paramref name="baseUri" />.</param>
        public SipUri(Uri baseUri, Uri relativeUri) : base(baseUri, relativeUri)
        {
            Initialize();
        }

        protected SipUri(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
            Initialize();
        }

        private void Initialize()
        {
            if (!string.Equals(Scheme, Constants.SipScheme, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Only sip: scheme is allowed, provided : " + Scheme);
            }

            if(!EmailRegex.IsMatch(PathAndQuery))
            {
                throw new ArgumentException(PathAndQuery + " is not a valid email address.");
            }
        }
    }
}
