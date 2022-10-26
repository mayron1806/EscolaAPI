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
        public Task<List<Aluno>> PegaPorEscolaAsync(Guid escolaID);
        public Task<List<Aluno>> PegaPorTurmaAsync(Guid turmaID);
    }
}