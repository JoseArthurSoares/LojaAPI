using System.ComponentModel.DataAnnotations;

namespace LojaAPI.Models;

public class Pedido
{
    [Key]
    public int PedidoId { get; set; }
    
    [Required (ErrorMessage = "O campo ClienteId é obrigatório.")]
    [Range(1,int.MaxValue, ErrorMessage = "O campo deve ser maior que 0")]
    public int ClienteId { get; set; }
    
    [Required (ErrorMessage = "O campo DataPedido é obrigatório.")]
    public DateTime DataPedido { get; set; }
}