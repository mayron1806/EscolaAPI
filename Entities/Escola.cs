using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaAPI.Entities;
public class Escola
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Nome { get; set; }
    public float Pontos { get; set; } = 0;
    public ICollection<Aluno> Alunos { get; set; }
    public ICollection<Turma> Turmas { get; set; }
}