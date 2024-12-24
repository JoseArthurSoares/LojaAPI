using LojaAPI.Models;
using LojaAPI.Repositories;

namespace LojaAPI.Services;

public class ProdutoPadraoService(IProdutoRepository _produtoRepository): ProdutoService
{
    public Task<Produto> Inserir(Produto produto)
    {
        if (produto == null)
        {
            throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
        }

        return _produtoRepository.Inserir(produto);
    }

    public Task<List<Produto>> ObterTodos()
    {
        return _produtoRepository.ObterTodos();
    }

    public Task<Produto?> ObterPorId(int id)
    {
        var produto = _produtoRepository.ObterPorId(id);
        if (produto == null)
        {
            throw new KeyNotFoundException("Produto não encontrado.");
        }
        return _produtoRepository.ObterPorId(id);
    }

    public Task<bool> Atualizar(Produto produto)
    {
        if (_produtoRepository.ObterPorId(produto.ProdutoId) == null)
        {
            throw new KeyNotFoundException("Produto não encontrado.");
        }
        if (produto == null)
        {
            throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
        }
        return _produtoRepository.Atualizar(produto);
    }

    public Task<bool> Excluir(int id)
    {
        var produto = _produtoRepository.ObterPorId(id);
        if (produto == null)
        {
            throw new KeyNotFoundException("Produto não encontrado.");
        }
        return _produtoRepository.Excluir(id);
    }
    
}