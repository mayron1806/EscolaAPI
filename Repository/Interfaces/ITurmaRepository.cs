using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAPI.Entities;

namespace EscolaAPI.Repository.Interfaces
{
    public interface ITurmaRepository: IGenericoRepository<Turma>
    {
        public Task<List<Turma>> PegaTurmasDaEscolaAsync(Guid escolaID);
    }
}