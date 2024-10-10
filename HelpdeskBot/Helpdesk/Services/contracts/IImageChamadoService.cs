using ChamadoDataAccessLibrary.Models;

namespace HelpdeskBot.Services.contracts
{
    public interface IImageChamadoService
    {
        Task AddImagesChamado(int chamadoId, List<IFormFile> files);
        Task<IEnumerable<ImageChamado>> GetImagesChamadoById(int id);
        Task UpdateImagesChamado(int id, ImageChamado imgChamado);
    }
}
