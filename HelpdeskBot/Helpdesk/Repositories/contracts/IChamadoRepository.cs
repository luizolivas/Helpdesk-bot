using ChamadoDataAccessLibrary.Models;

namespace HelpdeskBot.Repositories.contracts
{
    public interface IChamadoRepository
    {
        Task Create(Chamado chamado);
        Task<int> CreateReturnId(Chamado chamado);
        Task<List<Chamado>> GetAll();
        Task<Chamado> Get(int id);
        Task Update(int id, Chamado chamado);
        Task<List<Chamado>> GetByIdCliente(int id);
    }
}
