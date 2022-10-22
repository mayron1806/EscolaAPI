using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaAPI.Entities;
public class Escola
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    [Required] public string Nome { get; set; }
    public ICollection<Aluno> Alunos { get; set; }
}