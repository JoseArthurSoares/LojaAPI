using LojaAPI.Models;
using LojaAPI.Repositories;

namespace LojaAPI.Services;

public class ProdutoPadraoService
{
    private readonly IProdutoRepository _produtoRepository;
    
    public ProdutoPadraoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    
    public Task<Produto> Inserir(Produto produto)
    {
        return _produtoRepository.Inserir(produto);
    }

    public Task<List<Produto>> ObterTodos()
    {
        return _produtoRepository.ObterTodos();
    }

    public Task<Produto?> ObterPorId(int id)
    {
        return _produtoRepository.ObterPorId(id);
    }

    public Task<bool> Atualizar(Produto produto)
    {
        return _produtoRepository.Atualizar(produto);
    }

    public Task<bool> Excluir(int id)
    {
        return _produtoRepository.Excluir(id);
    }
    
}