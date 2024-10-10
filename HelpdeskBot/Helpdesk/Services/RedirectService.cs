using HelpdeskBot.Services.contracts;

namespace HelpdeskBot.Services
{
    public class RedirectService : IRedirectService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public RedirectService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public string ConfigRedirect(int cliente)
        {
            SaveSessionCliente(cliente);
            if(_configuration != null)
            {
                string apiUrl = _configuration["UrlFront:Url"];
                return apiUrl;
            }
            else
            {
                return "";
            }

        }

        public void SaveSessionCliente(int cliente)
        {
            if(cliente != 0)
            {
                var session = _httpContextAccessor.HttpContext.Session;
                session.SetInt32("ClienteId", cliente);
            }
        }
    }
}
