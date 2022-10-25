using EscolaAPI.Repository.Interfaces;
using EscolaAPI.Entities;
using System.Linq.Expressions;

namespace EscolaAPI.Services
{
    public class AlunoServices
    {
        private readonly IAlunoRepository _alunoRepo;
        private readonly IEscolaRepository _escolaRepo;

        public AlunoServices(IAlunoRepository alunoRepo, IEscolaRepository escolaRepo)
        {
            _alunoRepo = alunoRepo;
            _escolaRepo = escolaRepo;
        }

        #region SELECT        
        public async Task<List<Aluno>> PegaAlunosPorNome(Guid escolaID, string nome)
        {
            // verifica se a escola existe
            await EscolaServices.ValidaEscolaExiste(_escolaRepo, escolaID);
            
            var alunos = await _alunoRepo.PegaPorNomeAsync(escolaID, nome);
            if(alunos == null) throw new NullReferenceException("Nenhum aluno foi encontrado.");
            return alunos;
        }
        public async Task<List<Aluno>> PegaAlunosEscola(Guid escolaID)
        {   
            // verifica se a escola existe
            await EscolaServices.ValidaEscolaExiste(_escolaRepo, escolaID);
            
            var alunos = await _alunoRepo.PegaTodosDaEscolaAsync(escolaID);
            if(alunos == null) throw new NullReferenceException("Nenhum aluno foi encontrado.");
            return alunos;
        }
        public async Task<Aluno> PegaAlunoPorID(Guid ID)
        {
            var aluno = await _alunoRepo.PegaPorIdAsync(ID);
            if(aluno == null) throw new NullReferenceException("Nenhum aluno foi encontrado.");
            return aluno;
        }
        public async Task<List<Aluno>> PegaAlunosPorTurma(Guid escolaID, int turma)
        {
            // verifica se a escola existe
            await EscolaServices.ValidaEscolaExiste(_escolaRepo, escolaID);

            var alunos = await _alunoRepo.PegaPorTurmaAsync(escolaID, turma);
            if(alunos == null) throw new NullReferenceException("Nenhum aluno foi encontrado.");
            return alunos;
        }
        #endregion

        public async Task<Aluno> Adicionar(Aluno modelo)
        {
            return await _alunoRepo.AdicionarAsync(modelo);
        }
        public async Task<Aluno> Atualizar(Guid alunoID, Aluno modelo)
        {
            var aluno = await _alunoRepo.PegaPorIdAsync(alunoID);
            if(aluno == null) throw new NullReferenceException("Erro ao tentar atualizar o aluno. Aluno não encontrado.");
            modelo.ID = alunoID;
            return await _alunoRepo.AtualizarAsync(modelo);
        }
        public async Task<bool> Deletar(Guid id)
        {
            var aluno = await _alunoRepo.PegaPorIdAsync(id);
            if(aluno == null) throw new NullReferenceException("O aluno que você está tentando deletar não foi encontrado.");
            return await _alunoRepo.DeletarAsync(aluno);
        }
    }
}