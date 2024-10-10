using ChamadoDataAccessLibrary.Models;

namespace HelpdeskBot.Repositories.contracts
{
    public interface IUsuarioInternoRepository
    {
        Task Create(UsuarioInterno usuario);
        Task<List<UsuarioInterno>> GetAll();
        Task<UsuarioInterno> Get(int id);
        Task Update(UsuarioInterno usuario);
        Task Delete(UsuarioInterno usuario);
    }
}
