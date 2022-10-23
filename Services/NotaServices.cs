using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAPI.DTO;
using EscolaAPI.Entities;
using EscolaAPI.Repository.Interfaces;
namespace EscolaAPI.Services
{
    public class NotaServices
    {
        private readonly INotaRepository _notaRepo;
        private readonly IAlunoRepository _alunoRepo;
        public NotaServices(INotaRepository notaRepo, IAlunoRepository alunoRepo)
        {
            _alunoRepo = alunoRepo;
            _notaRepo = notaRepo;
        }
        public async Task<List<Nota>> PegaNotasPorAluno(Guid alunoID, int ano = 0)
        {
            // verifica se possui um aluno com o id
            var aluno = await _alunoRepo.PegaPorIdAsync(alunoID);
            if(aluno == null){
                throw new Exception("Este aluno não existe.");
            }
            // pega o ano atual se não for passado nenhum ano
            if(ano == 0){
                ano = DateTime.Now.Year;
            }
            var notas = await _notaRepo.PegaNotasDoAluno(alunoID, ano);
            return notas;
        }
        public async Task<int> SomaNotasDoBimestre(Guid alunoID, Bimestre bimestre, int ano)
        {
            // verifica se possui um aluno com o id
            var aluno = await _alunoRepo.PegaPorIdAsync(alunoID);
            if(aluno == null){
                throw new Exception("Este aluno não existe.");
            }
            // pega o ano atual se não for passado nenhum ano
            if(ano == 0){
                ano = DateTime.Now.Year;
            }
            var notas = await _notaRepo.PegaNotasDoBimestre(alunoID, bimestre, ano);

            // soma as notas do bimestre
            int resultadoBimestre = 0;
            foreach(Nota n in notas){ resultadoBimestre += n.Valor; }

            return resultadoBimestre;
        }
        // INSERT
        public async Task<Nota> Adicionar(Nota novaNota)
        {
            await _notaRepo.AdicionarAsync(novaNota);
            if(novaNota.ID == null){
                throw new Exception("Erro ao adicionar nota.");
            }
            return novaNota;
        }

        // UPDATE
        public async Task<Nota> Atualizar(Guid id, Nota novaNota)
        {
            var nota = await _notaRepo.PegaNotaPorID(id);
            if(nota == null) throw new NullReferenceException("Erro ao atualizar a nota. A nota não encontrada.");
            novaNota.ID = nota.ID;
            return await _notaRepo.AtualizarAsync(novaNota);
        }
        
        // DELETE
        public async Task<bool> Deletar(Guid id)
        {
            var escola = await _notaRepo.PegaNotaPorID(id);
            if(escola == null) throw new NullReferenceException("A nota que você está tentando deletar não foi encontrada.");
            return await _notaRepo.DeletarAsync(escola);
        }
    }
}