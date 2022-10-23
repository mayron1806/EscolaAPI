using EscolaAPI.Repository.Interfaces;
using EscolaAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Repository
{
    
    public class GenericoRepository<T> : IGenericoRepository<T>
    {
        private readonly EscolaContext _context;
        public GenericoRepository(EscolaContext context){ 
            _context = context;
        }

        public async Task<T> AdicionarAsync(T novaEntity){
            await _context.AddAsync(novaEntity);
            await _context.SaveChangesAsync();

            return novaEntity;
        }
        
        // UPDATE
        public async Task<T> AtualizarAsync(T novaEntity){
            _context.Update(novaEntity);
            await _context.SaveChangesAsync();
            return novaEntity;
        }

        // DELETE
        public async Task<bool> DeletarAsync(T entity){
            _context.Remove(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}