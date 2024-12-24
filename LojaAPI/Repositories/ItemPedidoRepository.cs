using LojaAPI.Data;
using LojaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Repositories;

public class ItemPedidoRepository: IItemPedidoRepository
{
    private readonly LojaDbContext _context;

    public ItemPedidoRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<ItemPedido> Inserir(ItemPedido itemPedido)
    {
        _context.ItemPedidos.Add(itemPedido);
        await _context.SaveChangesAsync();
        return itemPedido;
    }

    public async Task<IEnumerable<ItemPedido>> ObterTodos()
    {
        return await _context.ItemPedidos.ToListAsync();
    }

    public async Task<ItemPedido?> ObterPorId(int id)
    {
        return await _context.ItemPedidos.FindAsync(id);
    }

    public async Task<bool> Atualizar(ItemPedido itemPedido)
    {
        _context.ItemPedidos.Update(itemPedido);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Excluir(int id)
    {
        var itemPedido = await ObterPorId(id);
        if (itemPedido == null)
        {
            return false;
        }
        _context.ItemPedidos.Remove(itemPedido);
        await _context.SaveChangesAsync();
        return true;
    }
}