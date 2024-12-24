using LojaAPI.Data;
using LojaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Repositories;

public class PedidoRepository: IPedidoRepository
{
    private readonly LojaDbContext _context;

    public PedidoRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido> Inserir(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<IEnumerable<Pedido>> ObterTodos()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<Pedido?> ObterPorId(int id)
    {
        return await _context.Pedidos.FindAsync(id);
    }

    public async Task<bool> Atualizar(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Excluir(int id)
    {
        var pedido = await ObterPorId(id);
        if (pedido == null)
        {
            return false;
        }

        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
        return true;
    }
}