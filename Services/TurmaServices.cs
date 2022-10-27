using EscolaAPI.Entities;
using EscolaAPI.Entities.Enums;
using EscolaAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EscolaAPI.Services
{
    public class TurmaServices: GenericoService<Turma>
    {
        private readonly ITurmaRepository _turmaRepo;
        private readonly IEscolaRepository _escolaRepo;
        public TurmaServices(ITurmaRepository turmaRepo, IEscolaRepository escolaRepo): base(turmaRepo)
        {
            _turmaRepo = turmaRepo;
            _escolaRepo = escolaRepo;
        }
        public async Task<List<Turma>> PegaTurmasDaEscola(Guid escolaID)
        {
            var turmas = await _turmaRepo.PegaTurmasDaEscolaAsync(escolaID);
            if(turmas == null){
                throw new ArgumentException("O aluno não existe.");
            }
            return turmas;
        }
        public override async Task<Turma> Adicionar(Turma modelo)
        {
            // verifica se existe a escola
            var escola = await _escolaRepo.PegaPorIDAsync(modelo.EscolaID);
            if(escola == null){
                throw new ArgumentException("A escola não existe.");
            }
            // verifica nome duplicado
            var turmas = await _turmaRepo.PegaTurmasDaEscolaAsync(modelo.EscolaID);
            foreach(Turma t in turmas){
                if(t.Nome == modelo.Nome){
                    throw new ArgumentException("Já existe uma turma com esse nome.");
                }
            }
            return await base.Adicionar(modelo);
        }
    }
}