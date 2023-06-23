using System.ComponentModel.DataAnnotations;

namespace ProjetoValidacao.Models
{
    public class Conta
    {
        [Key]
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
