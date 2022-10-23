using EscolaAPI.Entities;
using EscolaAPI.Repository.Interfaces;
using EscolaAPI.Context;
using Microsoft.EntityFrameworkCore;
using EscolaAPI.DTO;

namespace EscolaAPI.Repository
{
    public class NotaRepository : GenericoRepository<Nota>, INotaRepository
    {
        private readonly EscolaContext _context;
        private readonly DbSet<Nota> _notaContext;
        public NotaRepository(EscolaContext context): base(context)
        {
            _context = context;
            _notaContext = context.Notas;
        }
        public async Task<List<Nota>> PegaNotasDoAluno(Guid alunoID, int ano)
        {
            var notas = await _notaContext
                .AsNoTracking()
                .Where(n => n.AlunoID == alunoID)
                .Where(n => n.Ano == ano)
                .ToListAsync();

            return notas;
        }

        public async Task<Nota> PegaNotaPorID(Guid id)
        {
            var nota = await _notaContext
                .AsNoTracking()
                .FirstOrDefaultAsync(n => n.ID == id);
            return nota;
        }

        public async Task<List<Nota>> PegaNotasDoBimestre(Guid alunoID, Bimestre bimestre, int ano)
        {
            var notas = await _notaContext
                .AsNoTracking()
                .Where(n => n.AlunoID == alunoID)
                .Where(n => n.Bimestre == bimestre)
                .Where(n => n.Ano == ano)
                .ToListAsync();
            return notas;
        }
    }
}