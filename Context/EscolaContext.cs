using EscolaAPI.Entities;
using Microsoft.EntityFrameworkCore;
namespace EscolaAPI.Context
{
    public class EscolaContext: DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options): base(options){ }
        public DbSet<Turma> Turmas{ get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Nota>()
                .Property(n => n.Bimestre)
                .HasConversion<string>();

            modelBuilder.Entity<Nota>()
                .Property(n => n.Materia)
                .HasConversion<string>();

            modelBuilder.Entity<Turma>()
                .HasOne(t => t.Escola)
                .WithMany(e => e.Turmas)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}