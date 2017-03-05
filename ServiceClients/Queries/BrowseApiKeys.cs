using Warden.Common.Queries;

namespace Warden.Common.ServiceClients.Queries
{
    public class BrowseApiKeys : PagedQueryBase
    {
        public string UserId { get; set; }
    }
}