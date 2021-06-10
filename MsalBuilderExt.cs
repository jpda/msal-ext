using System.Security.Cryptography.X509Certificates;
using Microsoft.Identity.Client;

namespace _425show.Msal.Extensions
{
    public static class MsalBuilderExt
    {
        public static ConfidentialClientApplicationBuilder WithCredential(this ConfidentialClientApplicationBuilder builder, IMsalCredential credential)
        {
            if (credential.GetType() == typeof(XPlatCertificateCredential))
            {
                var cert = credential.GetCredential<X509Certificate2>();
                builder.WithCertificate(cert);
                return builder;
            }
            builder.WithClientSecret(credential.GetCredential<string>());
            return builder;
        }
    }
}