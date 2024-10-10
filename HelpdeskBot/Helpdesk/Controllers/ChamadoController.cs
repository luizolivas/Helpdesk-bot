using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Services.contracts;
using Microsoft.AspNetCore.Mvc;

namespace HelpdeskBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;
        private readonly IImageChamadoService _imageChamadoService;

        public ChamadoController(IChamadoService chamadoService, IImageChamadoService imageChamadoService)
        {
            _chamadoService = chamadoService;
            _imageChamadoService = imageChamadoService;
        }

        [HttpPost]
        public async Task<ActionResult> Post_CreateChamado([FromBody] Chamado chamado)
        {
            try
            {
                //await _chamadoService.CreateChamado(chamado);
                int teste = await _chamadoService.CreateChamadoReturningId(chamado);
                return Ok(new { id = chamado.Id }); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get_AllChamados()
        {
            try
            {
                List<Chamado> chamados = await _chamadoService.GetAllChamados();
                return Ok(chamados);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetChamado/{id}")]
        public async Task<ActionResult> GetChamadoById(int id)
        {
            try
            {
                Chamado chamado = await _chamadoService.GetChamadoById(id);
                return Ok(chamado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetChamadoIdCliente")]
        public async Task<ActionResult> GetChamadoByIdCliente()
        {
            try
            {
                List<Chamado> chamado = await _chamadoService.GetChamadoByIdCliente();
                return Ok(chamado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateChamado/{id}")]
        public async Task<ActionResult> UpdateChamado(int id, Chamado chamado)
        {
            try
            {
                await _chamadoService.UpdateChamado(id,chamado);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
