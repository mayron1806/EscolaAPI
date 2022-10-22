using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EscolaAPI.Entities;

namespace EscolaAPI.Repository.Interfaces
{
    public interface IAlunoRepository: IGenericoRepository<Aluno>
    {
        
        public Task<Aluno> PegaPorIdAsync(Guid id);
        public Task<List<Aluno>> PegaTodosDaEscolaAsync(Guid escolaID);
        public Task<List<Aluno>> PegarPorNomeAsync(Guid escolaID, string nome); 
        public Task<List<Aluno>> PegarPorPresencaAsync(Guid escolaID, Expression<Func<Aluno, bool>> e); 
    }
}