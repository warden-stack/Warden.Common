using System.Threading.Tasks;
using Warden.Common.Types;

namespace Warden.Common.Security
{
    public interface IServiceAuthenticatorClient
    {
        Task<Maybe<string>> AuthenticateAsync(string serviceUrl, Credentials credentials);
    }
}