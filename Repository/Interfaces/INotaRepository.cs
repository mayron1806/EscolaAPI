using EscolaAPI.Entities;
using EscolaAPI.Entities.Enums;

namespace EscolaAPI.Repository.Interfaces
{
    public interface INotaRepository: IGenericoRepository<Nota>
    {
        public Task<List<Nota>> PegaDoAluno(Guid alunoID);
        public Task<List<Nota>> PegaDoAlunoPorAno(Guid alunoID, int ano);
         
        public Task<List<Nota>> PegaNotasDaTurma(Guid turmaID);

        public Task<float> PegaMediaNotaTurma(Guid turmaID);
    }
}