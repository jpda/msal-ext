using Microsoft.Extensions.Options;

namespace _425show.Msal.Extensions
{
    public class SecretCredential : IMsalCredential
    {
        private readonly SecretCredentialConfiguration _config;

        public SecretCredential(IOptions<SecretCredentialConfiguration> config)
        {
            _config = config.Value;
        }

        public T GetCredential<T>() where T : class
        {
            return _config.ClientSecret as T;
        }
    }
}