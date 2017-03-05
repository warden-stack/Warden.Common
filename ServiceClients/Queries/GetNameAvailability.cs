using Warden.Common.Queries;

namespace Warden.Common.ServiceClients.Queries
{
    public class GetNameAvailability : IQuery
    {
        public string Name { get; set; }
    }
}