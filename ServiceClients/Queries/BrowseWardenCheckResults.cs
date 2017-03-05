using System;
using Warden.Common.Queries;

namespace Warden.Common.ServiceClients.Queries
{
    public class BrowseWardenCheckResults : PagedQueryBase
    {
        public Guid OrganizationId { get; set; }
        public Guid WardenId { get; set; }
    }
}