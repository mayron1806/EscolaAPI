using EscolaAPI.Repository.Interfaces;
using EscolaAPI.Entities;
using System.Linq.Expressions;

namespace EscolaAPI.Services
{
    public class AlunoServices
    {
        private readonly IAlunoRepository _alunoRepo;
        public AlunoServices(IAlunoRepository alunoRepo)
        {
            _alunoRepo = alunoRepo;
        }

        #region SELECT        
        public async Task<List<Aluno>> PegaAlunosPorPresenca(Guid escolaID, string condicao, int presenca)
        {
            // verifica se condicao esta dentro das possibilidades
            if(!Presenca.possibilidadesCondicaoPresenca.Contains(condicao.ToLower())){
                string erro = "A condição fornecida não é valida. As condições validas são: \n" +
                    "'gt' (maior ou igual), 'g' (maior que), 'lt' (menor ou igual), 'l' (menor que).";
                throw new InvalidDataException(erro);
            }
            Expression<Func<Aluno, bool>> expressao;
            switch(condicao){
                case "lt":
                    expressao = a => a.Presenca <= presenca;
                    break;
                case "l":
                    expressao = a => a.Presenca < presenca;
                    break;
                case "g":
                    expressao = a => a.Presenca > presenca;
                    break;
                case "gt": default:
                    expressao = a => a.Presenca >= presenca;
                    break;
            }
            var alunos = await _alunoRepo.PegarPorPresencaAsync(escolaID, expressao);
            if(alunos == null) throw new NullReferenceException("Nenhum aluno foi encontrado");
            return alunos;
        }

        public async Task<List<Aluno>> PegaAlunosPorNome(Guid escolaID, string nome)
        {
            var alunos = await _alunoRepo.PegarPorNomeAsync(escolaID, nome);
            if(alunos == null) throw new NullReferenceException("Nenhum aluno foi encontrado.");
            return alunos;
        }
        public async Task<List<Aluno>> PegaAlunosEscola(Guid escolaID)
        {
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
        #endregion

        public async Task<Aluno> AdicionarAluno(Aluno modelo)
        {
            return await _alunoRepo.AdicionarAsync(modelo);
        }
        public async Task<Aluno> AtualizarAluno(Guid alunoID, Aluno modelo)
        {
            var aluno = await _alunoRepo.PegaPorIdAsync(alunoID);
            if(aluno == null) throw new NullReferenceException("Erro ao tentar atualizar o aluno. Aluno não encontrado.");
            return await _alunoRepo.AtualizarAsync(modelo);
        }
        public async Task<bool> DeletarAluno(Guid id){
            var aluno = await _alunoRepo.PegaPorIdAsync(id);
            if(aluno == null) throw new NullReferenceException("O aluno que você está tentando deletar não foi encontrado.");
            return await _alunoRepo.DeletarAsync(aluno);
        }
    }
}