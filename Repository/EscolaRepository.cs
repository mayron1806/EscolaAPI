using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EscolaAPI.Context;
using EscolaAPI.Entities;
using EscolaAPI.Repository.Interfaces;

namespace EscolaAPI.Repository
{
    public class EscolaRepository: IEscolaRepository
    {
        private readonly EscolaContext _context;
        private readonly DbSet<Escola> _escolaContext;
        public EscolaRepository(EscolaContext context)
        {
            _context = context;
            _escolaContext = context.Escolas;

        }

        // SELECT
        public async Task<Escola> PegaPorId(Guid id)
        {
            return await _escolaContext
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ID == id);
        }
         public async Task<List<Escola>> PegarPorNome(string nome)
        {
            var escolas = await _escolaContext
                .AsNoTracking()
                .Where(e => e.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();
            return escolas;
        }
        public async Task<List<Escola>> PegaTodos()
        {
            return await _escolaContext
                .AsNoTracking()
                .ToListAsync();
        }
        
        // INSERT
        public async Task<Escola> Adicionar(Escola novaEscola){
            await _escolaContext.AddAsync(novaEscola);
            await _context.SaveChangesAsync();

            return novaEscola;
        }
        
        // UPDATE
        public async Task<Escola> Atualizar(Escola novaEscola){
            _context.Update(novaEscola);
            await _context.SaveChangesAsync();
            return novaEscola;
        }

        // DELETE
        public async Task<bool> Deletar(Escola escola){
            _escolaContext.Remove(escola);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}