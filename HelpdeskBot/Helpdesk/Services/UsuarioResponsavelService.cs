using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Repositories.contracts;
using HelpdeskBot.Services.contracts;

namespace HelpdeskBot.Services
{
    public class UsuarioResponsavelService : IUsuarioResponsavelService
    {
        private readonly IUsuarioInternoRepository _repository;

        public UsuarioResponsavelService(IUsuarioInternoRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUsuario(UsuarioInterno usuario)
        {
            await _repository.Create(usuario);
        }

        public async Task DeleteUsuarioById(UsuarioInterno usuario)
        {
            await _repository.Delete(usuario);
        }

        public async Task<List<UsuarioInterno>> GetAllUsuario()
        {
            return await _repository.GetAll();
        }

        public async Task<UsuarioInterno> GetUsuarioById(int id)
        {
            return await _repository.Get(id);
        }

        public async Task UpdateUsuario(UsuarioInterno usuario)
        {
            await _repository.Update(usuario);
        }
    }
}
