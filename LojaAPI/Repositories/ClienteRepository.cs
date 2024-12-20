using LojaAPI.Data;
using LojaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly LojaDbContext _context;
    
    public ClienteRepository(LojaDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Cliente>> ObterTodos()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente?> ObterPorId(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<bool> Atualizar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Cliente> Inserir(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> Excluir(int id)
    {
        var cliente = await ObterPorId(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}