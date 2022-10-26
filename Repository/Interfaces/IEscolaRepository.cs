using EscolaAPI.Entities;

namespace EscolaAPI.Repository.Interfaces
{
    public interface IEscolaRepository: IGenericoRepository<Escola>
    {
        public Task<List<Escola>> PegaTodosAsync();
    }
}