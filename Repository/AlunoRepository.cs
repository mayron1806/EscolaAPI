using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EscolaAPI.Context;
using EscolaAPI.Entities;
using EscolaAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Repository
{
    public class AlunoRepository : GenericoRepository<Aluno>, IAlunoRepository
    {
        private readonly EscolaContext _context;
        private readonly DbSet<Aluno> _alunoContext;

        public AlunoRepository(EscolaContext context): base(context)
        {
            _context = context;
            _alunoContext = context.Alunos;
        }

        #region SELECT
        public async Task<List<Aluno>> PegaPorEscolaAsync(Guid escolaID)
        {
            var alunos = await _alunoContext
                .AsNoTracking()
                .Where(a => a.EscolaID == escolaID)
                .ToListAsync();
            return alunos;
        }

        public async Task<List<Aluno>> PegaPorTurmaAsync(Guid turmaID)
        {
            var alunos = await _alunoContext
                .AsNoTracking()
                .Where(a => a.TurmaID == turmaID)
                .ToListAsync();

            return alunos;
        }
        #endregion
    }
}