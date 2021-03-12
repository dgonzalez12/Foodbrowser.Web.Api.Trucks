using Foodbrowser.Core.Modules.Trucks.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Foodbrowser.Web.Api.Trucks.External
{
    /// <summary>
    /// Represents a socrata client.
    /// </summary>
    public class SocrataClient : ISocrataClient
    {
        /// <summary>
        /// Host.
        /// </summary>
        public string Host
        {
            get
            {
                var host = Configuration.GetValue<string>("SocrataClient:Host");
                if (string.IsNullOrEmpty(host))
                {
                    throw new TruckException("Cannot read configuration: SocrataClient:Host");
                }
                return host;
            }
        }

        /// <summary>
        /// Resource.
        /// </summary>
        public string Resource
        {
            get
            {
                var resource = Configuration.GetValue<string>("SocrataClient:Resource");
                if (string.IsNullOrEmpty(resource))
                {
                    throw new TruckException("Cannot read configuration: SocrataClient:Resource");
                }
                return resource;
            }
        }

        /// <summary>
        /// Instance of configuration object.
        /// </summary>
        private readonly IConfiguration Configuration;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration">Instance of configuration object.</param>
        public SocrataClient(IConfiguration configuration)
        {
            Configuration = configuration != null
                            ? configuration
                            : throw new TruckException($"Cannot find service: { nameof(configuration) }.");
        }
    }
}
