using HelpdeskBot.Services.contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpdeskBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedirectController : ControllerBase
    {
        
        private readonly IRedirectService _redirectService;

        public RedirectController(IRedirectService redirectService)
        {
            _redirectService = redirectService;
        }

        [HttpGet("/loginCliente")]
        public ActionResult GetClienteLogin([FromQuery] int clienteId)
        {
            try
            {

                string url = _redirectService.ConfigRedirect(clienteId);
                return Redirect(url);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
