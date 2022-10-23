using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAPI.DTO;
using EscolaAPI.Entities;

namespace EscolaAPI.Repository.Interfaces
{
    public interface INotaRepository: IGenericoRepository<Nota>
    {
        public Task<List<Nota>> PegaNotasDoAluno(Guid alunoID, int ano);
        public Task<Nota> PegaNotaPorID(Guid id);
        public Task<List<Nota>> PegaNotasDoBimestre(Guid alunoID, Bimestre bimestre, int ano);

    }
}