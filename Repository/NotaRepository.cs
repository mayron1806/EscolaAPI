using EscolaAPI.Entities;
using EscolaAPI.Repository.Interfaces;
using EscolaAPI.Context;
using Microsoft.EntityFrameworkCore;
using EscolaAPI.Entities.Enums;

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
        public async Task<List<Nota>> PegaDoAluno(Guid alunoID)
        {
            var notas = await _notaContext
                .AsNoTracking()
                .Where(n => n.AlunoID == alunoID)
                .ToListAsync();

            return notas;
        }
        public async Task<List<Nota>> PegaDoAlunoPorAno(Guid alunoID, int ano)
        {
            var notas = await _notaContext
                .AsNoTracking()
                .Where(n => n.AlunoID == alunoID)
                .Where(n => n.Ano == ano)
                .ToListAsync();

            return notas;
        }
        public async Task<List<Nota>> PegaNotasDaTurma(Guid turmaID){
            var notas = await _notaContext
                .AsNoTracking()
                .Where(n => n.Aluno.TurmaID == turmaID)
                .ToListAsync();
            return notas;
        }

        public async Task<float> PegaMediaNotaTurma(Guid turmaID)
        {
            var notas = await _notaContext
                .AsNoTracking()
                .Where(n => n.Aluno.TurmaID == turmaID)
                .ToListAsync();
            float media = 0f;
            foreach(Nota n in notas){
                media += n.Valor;
            }
            media = media / notas.Count;
            return media;
        }
    }
}