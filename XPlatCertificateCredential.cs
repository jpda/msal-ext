using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace _425show.Msal.Extensions
{
    public class XPlatCertificateCredential : IMsalCredential
    {
        private readonly CertificateCredentialConfiguration _config;
        private readonly ILogger _logger;
        public XPlatCertificateCredential(IOptions<CertificateCredentialConfiguration> config, ILogger<XPlatCertificateCredential> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        private X509Store GetCertificateStore()
        {
            var s = new X509Store(Enum.Parse<StoreName>(_config.Store.Name), Enum.Parse<StoreLocation>(_config.Store.Scope));
            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
            {
                s.Open(OpenFlags.ReadWrite);
                var certData = System.IO.File.ReadAllBytes(_config.File.Path);
                s.Add(new X509Certificate2(certData, _config.File.Password));
            }
            return s;
        }

        public T GetCredential<T>() where T : class
        {
            var store = GetCertificateStore();
            store.Open(OpenFlags.ReadOnly);
            foreach (var a in store.Certificates)
            {
                _logger.LogDebug($"{a.SubjectName.Name}");
            }

            var results = store.Certificates.Find(X509FindType.FindBySubjectName, _config.SubjectName, false);
            var cert = results[0];
            return cert as T;
        }
    }
}