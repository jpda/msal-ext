namespace _425show.Msal.Extensions
{
    public class CertificateCredentialConfiguration
    {
        public string SubjectName { get; set; }
        public CertificateFileCredentialConfiguration File { get; set; }
        public CertificateStoreCredentialConfiguration Store { get; set; }

        public class CertificateFileCredentialConfiguration
        {
            public string Path { get; set; }
            public string Password { get; set; }
        }

        public class CertificateStoreCredentialConfiguration
        {
            public string Name { get; set; }
            public string Scope { get; set; }
        }
    }
}