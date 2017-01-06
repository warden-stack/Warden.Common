namespace Warden.Common.Queries
{
    public abstract class AuthenticatedPagedQueryBase : PagedQueryBase, IAuthenticatedPagedQuery
    {
        public string UserId { get; set; }
    }
}