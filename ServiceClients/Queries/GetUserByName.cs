using Warden.Common.Queries;

namespace Warden.Common.ServiceClients.Queries
{
    public class GetUserByName : IQuery
    {
        public string Name { get; set; }
    }
}