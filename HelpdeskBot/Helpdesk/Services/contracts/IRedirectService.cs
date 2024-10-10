namespace HelpdeskBot.Services.contracts
{
    public interface IRedirectService
    {
        public void SaveSessionCliente(int cliente);
        public string ConfigRedirect(int cliente);
    }
}
