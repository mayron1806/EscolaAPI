using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaAPI.Entities
{
    public class Turma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        
        [Required] public Guid EscolaID { get; set; }
        public Escola Escola { get; set; }

        [Required] 
        [MaxLength(20)]
        public string Nome { get; set; }
        
        [MaxLength(30)]
        public List<Aluno> Alunos { get; set; }
    }
}