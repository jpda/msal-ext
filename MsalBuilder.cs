using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace _425show.Msal.Extensions
{
    public class MsalBuilder
    {
        private readonly AzureAdConfiguration _config;
        private readonly IMsalCredential _credential;

        public MsalBuilder(IOptions<AzureAdConfiguration> config, IMsalCredential credential)
        {
            _config = config.Value;
            _credential = credential;
        }

        public IConfidentialClientApplication Build()
        {
            var msal = ConfidentialClientApplicationBuilder
                .Create(_config.ClientId)
                .WithAuthority(_config.Authority)
                .WithCredential(_credential)
                .Build()
            ;
            return msal;
        }
    }
}