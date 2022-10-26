using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAPI.Context;
using EscolaAPI.Entities;
using EscolaAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Repository
{
    public class TurmaRepository : GenericoRepository<Turma>, ITurmaRepository
    {
        private readonly EscolaContext _context;
        private readonly DbSet<Turma> _turmaContext;
        public TurmaRepository(EscolaContext context): base(context)
        {
            _context = context;
            _turmaContext = context.Turmas;
        }


        public async Task<List<Turma>> PegaTurmasDaEscolaAsync(Guid escolaID)
        {
            var turmas = await _turmaContext
                .AsNoTracking()
                .Where(t => t.EscolaID == escolaID)
                .ToListAsync();
            return turmas;
        }
    }
}