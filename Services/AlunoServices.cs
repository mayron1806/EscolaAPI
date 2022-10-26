using EscolaAPI.Repository.Interfaces;
using EscolaAPI.Entities;
using System.Linq.Expressions;

namespace EscolaAPI.Services
{
    public class AlunoServices : GenericoService<Aluno>
    {
        private readonly IAlunoRepository _alunoRepo;
        private readonly IEscolaRepository _escolaRepo;

        public AlunoServices(IAlunoRepository alunoRepo, IEscolaRepository escolaRepo): base(alunoRepo)
        {
            _alunoRepo = alunoRepo;
            _escolaRepo = escolaRepo;
        }
        public async Task<List<Aluno>> PegaAlunosEscola(Guid escolaID)
        {   
            // verifica se a escola existe
            await EscolaServices.ValidaEscolaExiste(_escolaRepo, escolaID);
            
            var alunos = await _alunoRepo.PegaPorEscolaAsync(escolaID);
            if(alunos == null) throw new NullReferenceException("Erro ao buscar alunos da escola.");
            return alunos;
        }
        public async Task<List<Aluno>> PegaAlunosPorTurma(Guid turmaID)
        {
            var alunos = await _alunoRepo.PegaPorTurmaAsync(turmaID);
            if(alunos == null) throw new NullReferenceException("Erro ao buscar alunos da turma.");
            return alunos;
        }
    }
}