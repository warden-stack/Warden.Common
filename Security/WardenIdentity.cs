using System.Security.Claims;
using System.Security.Principal;

namespace Warden.Common.Security
{
    public class WardenIdentity : ClaimsPrincipal
    {
        public WardenIdentity(string name) : base(new GenericIdentity(name))
        {
        }
    }
}