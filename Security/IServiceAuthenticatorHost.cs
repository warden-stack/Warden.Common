using Warden.Common.Types;

namespace Warden.Common.Security
{
    public interface IServiceAuthenticatorHost
    {
         Maybe<string> CreateToken(Credentials credentials);
    }
}