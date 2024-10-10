using HelpdeskBot.Context;
using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Repositories.contracts;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskBot.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly ApplicationDbContext _context;

        public ChamadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Chamado chamado)
        {
            _context.Chamado.Add(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateReturnId(Chamado chamado)
        {
            _context.Chamado.Add(chamado);
            await _context.SaveChangesAsync();

            return chamado.Id;
        }

        public async Task<Chamado> Get(int id)
        {
            return await _context.Chamado.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Chamado>> GetAll()
        {
            List<Chamado> chamados = await _context.Chamado.ToListAsync();
            return chamados;
        }

        public async Task<List<Chamado>> GetByIdCliente(int id)
        {
            List<Chamado> chamados = await _context.Chamado.Where(x => x.IdCliente == id).ToListAsync();
            return chamados;
        }

        public async Task Update(int id, Chamado chamado)
        {
            Chamado item = await Get(id);

            if(item != null)
            {
                item.Title = chamado.Title;
                item.Description = chamado.Description;
                item.User = chamado.User;
                item.Codes = chamado.Codes;
                item.Status = chamado.Status;
                item.CreatedAt = chamado.CreatedAt;
                item.InternalDescription = chamado.InternalDescription;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Chamado não encontrado.");
            }

        }
    }
}
