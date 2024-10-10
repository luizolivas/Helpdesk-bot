using ChamadoDataAccessLibrary.Models;

namespace HelpdeskBot.Services.contracts
{
    public interface IChamadoService
    {
        Task CreateChamado(Chamado chamado);
        Task<int> CreateChamadoReturningId(Chamado chamado);
        Task<List<Chamado>> GetAllChamados();
        Task<Chamado> GetChamadoById(int id);
        Task<List<Chamado>> GetChamadoByIdCliente();
        Task UpdateChamado(int id, Chamado chamado);
    }
}
