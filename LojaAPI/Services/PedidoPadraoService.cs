using LojaAPI.Models;
using LojaAPI.Repositories;

namespace LojaAPI.Services;

public class PedidoPadraoService(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository)
{
    public Task<Pedido> Inserir(Pedido pedido)
    {
        if (pedido == null)
        {
            throw new ArgumentNullException(nameof(pedido), "O pedido não pode ser nulo.");
        }

        if (clienteRepository.ObterPorId(pedido.ClienteId) == null)
        {
            throw new KeyNotFoundException("Cliente não encontrado.");
        }
        return pedidoRepository.Inserir(pedido);
    }

    public Task<IEnumerable<Pedido>> ObterTodos()
    {
        return pedidoRepository.ObterTodos();
    }

    public Task<Pedido?> ObterPorId(int id)
    {
        if (pedidoRepository.ObterPorId(id) == null)
        {
            throw new KeyNotFoundException("Pedido não encontrado.");
        }
        return pedidoRepository.ObterPorId(id);
    }

    public Task<bool> Atualizar(Pedido pedido)
    {
        if (pedidoRepository.ObterPorId(pedido.PedidoId) == null)
        {
            throw new KeyNotFoundException("Pedido não encontrado.");
        }
        if (pedido == null)
        {
            throw new ArgumentNullException(nameof(pedido), "O pedido não pode ser nulo.");
        }
        if (clienteRepository.ObterPorId(pedido.ClienteId) == null)
        {
            throw new KeyNotFoundException("Cliente não encontrado.");
        }
        return pedidoRepository.Atualizar(pedido);
    }

    public Task<bool> Excluir(int id)
    {
        if (pedidoRepository.ObterPorId(id) == null)
        {
            throw new KeyNotFoundException("Pedido não encontrado.");
        }
        return pedidoRepository.Excluir(id);
    }
}