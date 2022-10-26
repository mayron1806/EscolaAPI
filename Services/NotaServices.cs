using EscolaAPI.Entities;
using EscolaAPI.Entities.Enums;
using EscolaAPI.Repository.Interfaces;
namespace EscolaAPI.Services
{
    public class NotaServices: GenericoService<Nota>
    {
        private readonly INotaRepository _notaRepo;
        private readonly IAlunoRepository _alunoRepo;
        public NotaServices(INotaRepository notaRepo, IAlunoRepository alunoRepo): base(notaRepo)
        {
            _alunoRepo = alunoRepo;
            _notaRepo = notaRepo;
        }
        public async Task<Nota> PegaNotasPorID(Guid notaID)
        {
            // verifica se possui um aluno com o id
            var nota = await _notaRepo.PegaPorIDAsync(notaID);
            if(nota == null){
                throw new Exception("Este aluno não existe.");
            }
            return nota;
        }
        public async Task<List<Nota>> PegaNotasDoAluno(Guid alunoID, int ano)
        {
            var aluno = await _alunoRepo.PegaPorIDAsync(alunoID);
            if(aluno == null){
                throw new ArgumentException("O aluno não existe.");
            }
            List<Nota> notas;
            int anoAtual = DateTime.Now.Year;
            if(ano <= 0 || ano > anoAtual){
                notas = await _notaRepo.PegaDoAluno(alunoID);
            }else{
                notas = await _notaRepo.PegaDoAlunoPorAno(alunoID, ano);
            }
            return notas;
        }
    }
}