using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaAPI.Entities;
public class Aluno
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    [Required]
    [MaxLength(200)]
    public string Nome { get; set; }
    
    [Required] public Guid EscolaID { get; set; }
    public Escola Escola { get; set; }
    
    [Required] public Guid TurmaID { get; set; }
    public Turma Turma { get; set; }

    [Required] public DateTime DataNascimento { get; set; }
    public int Presenca { get; set; } = 0;
    public ICollection<Nota> Notas { get; set; }
}