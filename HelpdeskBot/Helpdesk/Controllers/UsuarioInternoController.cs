using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Repositories.contracts;
using HelpdeskBot.Services;
using HelpdeskBot.Services.contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpdeskBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioInternoController : ControllerBase
    {
        private readonly IUsuarioResponsavelService _usuarioResponsavelService;
        

        public UsuarioInternoController(IUsuarioResponsavelService usuarioResponsavelService)
        {
            _usuarioResponsavelService = usuarioResponsavelService;
        }

        [HttpGet]
        public async Task<ActionResult> Get_AllUsuarios()
        {
            try
            {
                List<UsuarioInterno> usuarios = await _usuarioResponsavelService.GetAllUsuario();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetUsuario/{id}")]
        public async Task<ActionResult> GetChamadoById(int id)
        {
            try
            {
                UsuarioInterno usuario = await _usuarioResponsavelService.GetUsuarioById(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post_CreateChamado([FromBody] UsuarioInterno usuario)
        {
            try
            {
                //await _chamadoService.CreateChamado(chamado);
                await _usuarioResponsavelService.CreateUsuario(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
