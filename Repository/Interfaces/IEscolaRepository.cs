using EscolaAPI.Entities;

namespace EscolaAPI.Repository.Interfaces
{
    public interface IEscolaRepository : IGenericoRepository<Escola>
    {
        public Task<Escola> PegaPorIdAsync(Guid id);
        public Task<List<Escola>> PegaTodosAsync();
        public Task<List<Escola>> PegarPorNomeAsync(string name); 
    }
}