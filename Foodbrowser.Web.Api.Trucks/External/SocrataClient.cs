using Foodbrowser.Core.Modules.Trucks.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Foodbrowser.Web.Api.Trucks.External
{
    public class SocrataClient : ISocrataClient
    {
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

        private readonly IConfiguration Configuration;

        public SocrataClient(IConfiguration configuration)
        {
            Configuration = configuration != null
                            ? configuration
                            : throw new TruckException($"Cannot find service: { nameof(configuration) }.");
        }
    }
}
