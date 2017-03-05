using System;
using Warden.Common.Queries;

namespace Warden.Common.ServiceClients.Queries
{
    public class GetUserSession : IQuery
    {
        public Guid Id { get; set; }
    }
}