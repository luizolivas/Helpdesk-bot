using ChamadoDataAccessLibrary.Models;

namespace HelpdeskBot.Repositories.contracts
{
    public interface IImageChamadoRepository
    {
        Task Create(List<ImageChamado> imgChamado);
        Task<IEnumerable<ImageChamado>> GetById(int id);
        Task Update(int id, ImageChamado imgChamado);
    }
}
