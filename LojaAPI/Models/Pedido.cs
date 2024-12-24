namespace LojaAPI.Models;

public class Pedido
{
    public int PedidoId { get; set; }
    public int ClienteId { get; set; }
    public DateTime DapaPedido { get; set; }
}