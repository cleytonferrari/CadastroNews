using System.ComponentModel.DataAnnotations;

namespace CadastroNews.Models
{
    public class Fonte
    {
        public int FonteId { get; set; }

        [Required(ErrorMessage = "Preencha este campo.")]
        [StringLength(50,MinimumLength = 2,ErrorMessage = "O campo deve conter de 2 a 50 caracteres")]
        public string Nome { get; set; }
        
        public string Contato { get; set; }
    }
}