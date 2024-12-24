using LojaAPI.Models;

namespace LojaAPI.Services;


public interface ItemPedidoService
{
    Task<ItemPedido> Inserir(ItemPedido itemPedido);
    Task<IEnumerable<ItemPedido>> ObterTodos();
    Task<ItemPedido?> ObterPorId(int id);
    Task<bool> Atualizar(ItemPedido itemPedido);
    Task<bool> Excluir(int id);
}