using EscolaAPI.Repository.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace EscolaAPI.Services
{
    public class GenericoService<T> where T: class
    {
        private readonly IGenericoRepository<T> _repo;
        public GenericoService(IGenericoRepository<T> repo)
        {
            _repo = repo;
        }
        public virtual async Task<T> PegaPorID(Guid ID)
        {
            var entity = await _repo.PegaPorIDAsync(ID);
            if(entity == null) throw new NullReferenceException("Não encontrado.");
            return entity;
        }
        public virtual async Task<T> Adicionar(T modelo)
        {
            return await _repo.AdicionarAsync(modelo);
        }
        public virtual async Task<T> Atualizar(Guid alunoID, JsonPatchDocument<T> modelo)
        {
            var aluno = await _repo.PegaPorIDAsync(alunoID);
            if(aluno == null) throw new NullReferenceException("Erro ao tentar atualizar.");
            modelo.ApplyTo(aluno);
            return await _repo.AtualizarAsync(aluno);
        }
        public virtual async Task<bool> Deletar(Guid id)
        {
            var aluno = await _repo.PegaPorIDAsync(id);
            if(aluno == null) throw new NullReferenceException("Erro ao tentar deletar. Não encontrado.");
            return await _repo.DeletarAsync(aluno);
        }
    }
}