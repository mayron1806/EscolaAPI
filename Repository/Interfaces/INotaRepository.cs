using EscolaAPI.Entities;
using EscolaAPI.Entities.Enums;

namespace EscolaAPI.Repository.Interfaces
{
    public interface INotaRepository: IGenericoRepository<Nota>
    {
        public Task<List<Nota>> PegaNotasDoAluno(Guid alunoID, int ano);
        public Task<Nota> PegaNotaPorID(Guid id);
        public Task<List<Nota>> PegaNotasDoBimestre(Guid alunoID, Bimestre bimestre, int ano);

    }
}