using Warden.Common.Queries;

namespace Warden.Common.ServiceClients.Queries
{
    public class GetApiKey : PagedQueryBase
    {
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}