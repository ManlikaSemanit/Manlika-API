namespace Manlika_WebApi.App_Start
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
