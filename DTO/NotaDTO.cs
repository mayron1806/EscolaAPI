using EscolaAPI.Entities.Enums;

namespace EscolaAPI.DTO
{
    public class NotaDTO
    {
        public Guid ID { get; set; }
        public Guid AlunoID { get; set;}
        public string NomeAluno { get; set; }
        public string Nome { get; set; }
        public int Valor { get; set; }
        public int Ano { get; set; }
        public Bimestre Bimestre { get; set; }
    }
}