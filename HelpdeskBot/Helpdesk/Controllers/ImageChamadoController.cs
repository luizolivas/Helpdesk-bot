using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Services.contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpdeskBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageChamadoController : ControllerBase
    {
        private readonly IImageChamadoService _imageChamadoService;


        public ImageChamadoController(IImageChamadoService imageChamadoService)
        {
            _imageChamadoService = imageChamadoService;
        }

        [HttpPost]
        public async Task<ActionResult> UploadImages([FromForm] int chamadoId, [FromForm] List<IFormFile> files)
        {
            try
            {
                await _imageChamadoService.AddImagesChamado(chamadoId, files);
                return Ok("Imagens enviadas com sucesso.");

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        [HttpGet("{chamadoId}")]
        public async Task<ActionResult> GetImages(int chamadoId)
        {
            try
            {
                string aa = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                var listImages = await _imageChamadoService.GetImagesChamadoById(chamadoId);
                return Ok(listImages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
