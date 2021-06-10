namespace _425show.Msal.Extensions
{
    public interface IMsalCredential
    {
        T GetCredential<T>() where T : class;
    }
}