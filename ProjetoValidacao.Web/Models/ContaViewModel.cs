using System.ComponentModel.DataAnnotations;

namespace ProjetoValidacao.Web.Models
{
    public class ContaViewModel
    {
        [Display(Name = "Nome", Description = "Nome da conta", GroupName = "Conta")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; } = null!;
        [Display(Name = "Descrição", Description = "Descrição da conta", GroupName = "Conta")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Descricao { get; set; } = null!;
    }
}
