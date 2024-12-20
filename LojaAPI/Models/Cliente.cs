using System.ComponentModel.DataAnnotations;

namespace LojaAPI.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; } // Chave primária

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(60, ErrorMessage = "O nome deve ter no máximo 60 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [StringLength(40, ErrorMessage = "O nome deve ter no máximo 40 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [StringLength(11, ErrorMessage = "O nome deve ter no máximo 11 caracteres.")]
        public string Telefone { get; set; } = string.Empty;
    }
}
