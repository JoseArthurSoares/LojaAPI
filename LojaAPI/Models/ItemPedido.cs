using System.ComponentModel.DataAnnotations;

namespace LojaAPI.Models;


public class ItemPedido
{
    [Key]
    public int ItemPedidoId { get; set; }
    
    [Required(ErrorMessage = "O pedido é obrigatório.")]
    public int PedidoId { get; set; }
    
    [Required(ErrorMessage = "O produto é obrigatório.")]
    public int ProdutoId { get; set; }
    
    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int Quantidade { get; set; }
    
    [Required(ErrorMessage = "O preço unitário é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O preço unitário deve ser maior que zero.")]
    public decimal PrecoUnitario { get; set; }
}