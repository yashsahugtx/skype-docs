using Microsoft.Rtc.Internal.Platform.ResourceContract;
using Microsoft.SfB.PlatformService.SDK.Common;
using System;
using System.Threading.Tasks;

namespace Microsoft.SfB.PlatformService.SDK.ClientModel
{
    internal class Discover : BasePlatformResource<DiscoverResource, DiscoverCapability>, IDiscover
    {
        #region Public properties

        /// <summary>
        /// Get Appplication
        /// </summary>
        public IApplications Applications { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="restfulClient"></param>
        /// <param name="resource"></param>
        /// <param name="baseUri"></param>
        /// <param name="resourceUri"></param>
        internal Discover(IRestfulClient restfulClient, Uri baseUri, Uri resourceUri, object parent)
                : base(restfulClient, null, baseUri, resourceUri, parent)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Call Get on application and initialize communication resource
        /// </summary>
        /// <param name="loggingContext"></param>
        /// <returns></returns>
        public async Task RefreshAndInitializeAsync(LoggingContext loggingContext, string endpointId)
        {
            await this.RefreshAsync(loggingContext).ConfigureAwait(false);
            if (this.PlatformResource.Applications != null)
            {
                Uri baseUri = UriHelper.GetBaseUriFromAbsoluteUri(this.PlatformResource.Applications.Href);
                Uri applicationsUri = new Uri(this.PlatformResource.Applications.Href);
                if (!string.IsNullOrEmpty(endpointId))
                {
                    applicationsUri = UriHelper.AppendQueryParameterOnUrl(applicationsUri.ToString(), Constants.EndpointId, endpointId, false);
                }
                Applications = new Applications(this.RestfulClient, null, baseUri, applicationsUri, this);
            }
            else
            {
                throw new RemotePlatformServiceException("Retrieved DiscoverResource doesn't have link to ApplicationsResource.");
            }
        }

        /// <summary>
        /// Gets whether a particular capability is available or not.
        /// </summary>
        /// <param name="capability">Capability that needs to be checked.</param>
        /// <returns><code>true</code> iff the capability is available as of now.</returns>
        /// <remarks>Capabilities can change when a resource is updated. So, this method returning <code>true</code> doesn't guarantee that
        /// the capability will be available when it is actually used. Make sure to catch <see cref="T:Microsoft.SfB.PlatformService.SDK.Common.CapabilityNotAvailableException" /></remarks>
        public override bool Supports(DiscoverCapability capability)
        {
            return false;
        }

        #endregion
    }
}
