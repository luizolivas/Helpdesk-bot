using HelpdeskBot.Context;
using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Repositories.contracts;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskBot.Repositories
{
    public class ImageChamadoRepository : IImageChamadoRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageChamadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(List<ImageChamado> imgChamado)
        {
            _context.ImageChamado.AddRange(imgChamado);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImageChamado>> GetById(int id)
        {
            return await _context.ImageChamado.Where(x => x.ChamadoId == id).ToListAsync();
        }

        public Task Update(int id, ImageChamado imgChamado)
        {
            throw new NotImplementedException();
        }
    }
}
