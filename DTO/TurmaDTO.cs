using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EscolaAPI.Entities;

namespace EscolaAPI.DTO
{
    public class TurmaDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Guid EscolaID { get; set; }  
        
        [Required] 
        [MaxLength(20)]
        public string Nome { get; set; }
        
        [MaxLength(30)]
        public List<Aluno> Alunos { get; set; }
    }
}