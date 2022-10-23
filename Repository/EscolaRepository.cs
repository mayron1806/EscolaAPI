using Microsoft.EntityFrameworkCore;
using EscolaAPI.Context;
using EscolaAPI.Entities;
using EscolaAPI.Repository.Interfaces;

namespace EscolaAPI.Repository
{
    public class EscolaRepository: GenericoRepository<Escola>, IEscolaRepository
    {
        private readonly EscolaContext _context;
        private readonly DbSet<Escola> _escolaContext;
        public EscolaRepository(EscolaContext context): base(context)
        {
            _context = context;
            _escolaContext = context.Escolas;
        }

        // SELECT
        public async Task<Escola> PegaPorIdAsync(Guid id)
        {
            return await _escolaContext
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ID == id);
        }
         public async Task<List<Escola>> PegarPorNomeAsync(string nome)
        {
            var escolas = await _escolaContext
                .AsNoTracking()
                .Where(e => e.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();
            return escolas;
        }
        public async Task<List<Escola>> PegaTodosAsync()
        {
            return await _escolaContext
                .AsNoTracking()
                .ToListAsync();
        }
    }
}