using System.ComponentModel.DataAnnotations;

namespace LojaAPI.Models;

public class Produto
{
    [Key]
    public int ProdutoId { get; set; }
    
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(60, ErrorMessage = "O nome deve ter no máximo 60 caracteres.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "A preço do produto é obrigatório.")]
    public decimal Preco { get; set; }
    
    [Required(ErrorMessage = "O estoque do produto é obrigatório.")]
    public int Estoque { get; set; }
}