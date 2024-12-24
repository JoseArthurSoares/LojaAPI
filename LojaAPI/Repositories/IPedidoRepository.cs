using LojaAPI.Models;

namespace LojaAPI.Repositories;

public interface IPedidoRepository
{
    Task<Pedido> Inserir(Pedido pedido);
    Task<IEnumerable<Pedido>> ObterTodos();
    Task<Pedido?> ObterPorId(int id);
    Task<bool> Atualizar(Pedido pedido);
    Task<bool> Excluir(int id);
}