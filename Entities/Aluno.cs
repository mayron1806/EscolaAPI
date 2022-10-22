using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaAPI.Entities;
public class Aluno
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    [Required] public string Nome { get; set; }
    
    public Guid EscolaID { get; set; }
    public Escola Escola { get; set; }
    
    public int Presenca { get; set; } = 0;
    public ICollection<Nota> Notas { get; set; }
}