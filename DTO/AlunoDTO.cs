using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaAPI.DTO;
public class AlunoDTO
{
    public Guid ID { get; set; }
    public string Nome { get; set; }
    public Guid EscolaID { get; set; }
    public int Presenca { get; set; }
}