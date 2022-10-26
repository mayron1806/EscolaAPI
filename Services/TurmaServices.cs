using EscolaAPI.Entities;
using EscolaAPI.Entities.Enums;
using EscolaAPI.Repository.Interfaces;
namespace EscolaAPI.Services
{
    public class TurmaServices: GenericoService<Turma>
    {
        private readonly ITurmaRepository _turmaRepo;
        public TurmaServices(ITurmaRepository turmaRepo): base(turmaRepo)
        {
            _turmaRepo = turmaRepo;
        }
        public async Task<List<Turma>> PegaTurmasDaEscola(Guid escolaID)
        {
            var turmas = await _turmaRepo.PegaTurmasDaEscolaAsync(escolaID);
            if(turmas == null){
                throw new ArgumentException("O aluno não existe.");
            }
            return turmas;
        }
    }
}