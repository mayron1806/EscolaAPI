using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EscolaAPI.Entities.Enums;

namespace EscolaAPI.Entities
{
    public class Nota
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        
        [Required] public Guid AlunoID { get; set; }
        public Aluno Aluno { get; set; }
        
        [Required] public string Nome { get; set; }
        [Required] public Materia Materia { get; set; }
        [Required] public int Valor { get; set; }
        [Required] public int Ano { get; set; }
        [Required] public Bimestre Bimestre { get; set; }
    }
}