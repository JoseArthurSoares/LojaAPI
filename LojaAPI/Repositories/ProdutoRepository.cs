using LojaAPI.Data;
using LojaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Repositories;

public class ProdutoRepository
{
    private readonly LojaDbContext _context;

    public ProdutoRepository(LojaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ObterTodos()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto> ObterPorId(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task<Produto> Inserir(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<bool> Atualizar(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Excluir(int id)
    {
        var produto = await ObterPorId(id);
        if (produto == null)
        {
            return false;
        }

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return true;
    }
}