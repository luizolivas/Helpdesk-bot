using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Repositories.contracts;
using HelpdeskBot.Services.contracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HelpdeskBot.Services
{
    public class ChamadoService : IChamadoService
    {
        private readonly IChamadoRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChamadoService(IChamadoRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateChamado(Chamado chamado)
        {
            await _repository.Create(chamado);
        }

        public async Task<int> CreateChamadoReturningId(Chamado chamado)
        {
            int? clienteId = _httpContextAccessor.HttpContext.Session.GetInt32("ClienteId");
            if(clienteId == null)
            {
                throw new UnauthorizedAccessException("ClienteId não encontrado na sessão.");
            }
            chamado.IdCliente = Convert.ToInt32(clienteId);
            int result = await _repository.CreateReturnId(chamado);
            return result;
        }

        public async Task<List<Chamado>> GetAllChamados()
        {
            return await _repository.GetAll();
        }

        public async Task<Chamado> GetChamadoById(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Chamado>> GetChamadoByIdCliente()
        {
            int id = GetSessionId();
            return await _repository.GetByIdCliente(id); 
        }

        public async Task UpdateChamado(int id, Chamado chamado)
        {
            await _repository.Update(id, chamado);
        }

        public int GetSessionId()
        {
            int? clienteId = _httpContextAccessor.HttpContext.Session.GetInt32("ClienteId");
            if (clienteId == null)
            {
                throw new UnauthorizedAccessException("ClienteId não encontrado na sessão.");
            }

            return Convert.ToInt32(clienteId);
        }
    }
}
