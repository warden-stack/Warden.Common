using System;
using Warden.Common.Queries;

namespace Warden.Common.ServiceClients.Queries
{
    public class GetOperation : IQuery
    {
        public Guid RequestId { get; set; }
    }
}