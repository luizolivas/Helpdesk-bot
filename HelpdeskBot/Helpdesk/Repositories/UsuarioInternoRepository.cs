using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Context;
using HelpdeskBot.Repositories.contracts;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskBot.Repositories
{
    public class UsuarioInternoRepository : IUsuarioInternoRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioInternoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(UsuarioInterno usuario)
        {
            _context.UsuarioInterno.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(UsuarioInterno usuario)
        {
            _context.UsuarioInterno.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public Task<UsuarioInterno> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsuarioInterno>> GetAll()
        {
            List<UsuarioInterno> usuarios = await _context.UsuarioInterno.ToListAsync();
            return usuarios;
        }

        public async Task Update(UsuarioInterno usuario)
        {
            _context.UsuarioInterno.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
