using Warden.Common.Queries;

namespace Warden.Common.ServiceClients.Queries
{
    public class GetUser : IQuery
    {
        public string Id { get; set; }
    }
}