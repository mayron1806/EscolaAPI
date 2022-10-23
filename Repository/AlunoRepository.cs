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
        /// <summary>
        ///     Retorna um "IQueriyable" que contem um filtro dos alunos por escola.
        /// </summary>
        /// <param name="escolaID">ID da escola para filtrar os alunos</param>
        /// <returns></returns>
        private IQueryable<Aluno> FiltraPorEscola(Guid escolaID){
            return _alunoContext.Where(a => a.EscolaID == escolaID);
        }
        
        #region SELECT
        public async Task<Aluno> PegaPorIdAsync(Guid id)
        {
            return await _alunoContext
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<List<Aluno>> PegarPorNomeAsync(Guid escolaID, string nome)
        {
            var query = FiltraPorEscola(escolaID)
                .AsNoTracking()
                .Where(a => a.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToListAsync();
        }

        public async Task<List<Aluno>> PegarPorPresencaAsync(Guid escolaID, Expression<Func<Aluno, bool>> e)
        {
            var query = FiltraPorEscola(escolaID)
                .AsNoTracking()
                .Where(e);
            return await query.ToListAsync();
        }

        public async Task<List<Aluno>> PegaTodosDaEscolaAsync(Guid escolaID)
        {
            var query = FiltraPorEscola(escolaID)
                .AsNoTracking();
            return await query.ToListAsync();
        }
        #endregion
    }
}