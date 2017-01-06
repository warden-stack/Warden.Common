using Warden.Common.Queries;

namespace Warden.Common.Domain
{
    public interface IAuthenticatedQuery : IQuery
    {
        string UserId { get; set; }
    }
}