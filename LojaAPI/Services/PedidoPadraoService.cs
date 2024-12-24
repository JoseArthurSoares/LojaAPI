using LojaAPI.Models;
using LojaAPI.Repositories;

namespace LojaAPI.Services;

public class PedidoPadraoService
{
    
    private readonly IPedidoRepository _pedidoRepository;
    
    public Task<Pedido> Inserir(Pedido pedido)
    {
        return this._pedidoRepository.Inserir(pedido);
    }

    public Task<IEnumerable<Pedido>> ObterTodos()
    {
        return this._pedidoRepository.ObterTodos();
    }

    public Task<Pedido?> ObterPorId(int id)
    {
        return this._pedidoRepository.ObterPorId(id);
    }

    public Task<bool> Atualizar(Pedido pedido)
    {
        return this._pedidoRepository.Atualizar(pedido);
    }

    public Task<bool> Excluir(int id)
    {
        return this._pedidoRepository.Excluir(id);
    }
}