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

        
        public async Task<List<Escola>> PegaTodosAsync()
        {
            return await _escolaContext
                .AsNoTracking()
                .ToListAsync();
        }
    }
}