using LojaAPI.Models;
using LojaAPI.Repositories;

namespace LojaAPI.Services;

public class ItemPedidoPadraoService(
    IItemPedidoRepository _itemPedidoRepository,
    IPedidoRepository pedidoRepository,
    IProdutoRepository produtoRepository)
    : ItemPedidoService
{
    public async Task<ItemPedido> Inserir(ItemPedido itemPedido)
    {
        if (itemPedido == null)
            throw new ArgumentNullException(nameof(itemPedido), "O item do pedido não pode ser nulo.");

        // Validar existência do pedido
        var pedido = await pedidoRepository.ObterPorId(itemPedido.PedidoId);
        if (pedido == null)
            throw new KeyNotFoundException("Pedido não encontrado.");

        // Validar existência do produto
        var produto = await produtoRepository.ObterPorId(itemPedido.ProdutoId);
        if (produto == null)
            throw new KeyNotFoundException("Produto não encontrado.");

        // Validar estoque disponível
        if (produto.Estoque < itemPedido.Quantidade)
            throw new InvalidOperationException("Estoque insuficiente para a quantidade solicitada.");

        // Inserir no repositório
        return await _itemPedidoRepository.Inserir(itemPedido);

    }

    public Task<IEnumerable<ItemPedido>> ObterTodos()
    {
        return _itemPedidoRepository.ObterTodos();
    }

    public Task<ItemPedido?> ObterPorId(int id)
    {
        return _itemPedidoRepository.ObterPorId(id);
    }

    public Task<bool> Atualizar(ItemPedido itemPedido)
    {
        return _itemPedidoRepository.Atualizar(itemPedido);
    }

    public Task<bool> Excluir(int id)
    {
        return _itemPedidoRepository.Excluir(id);
    }
}