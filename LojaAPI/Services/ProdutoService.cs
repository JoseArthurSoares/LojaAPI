using LojaAPI.Models;

namespace LojaAPI.Services;

public interface ProdutoService
{
    Task<Produto> Inserir(Produto produto);
    Task<List<Produto>> ObterTodos();
    Task<Produto> ObterPorId(int id);
    Task<bool> Atualizar(Produto produto);
    Task<bool> Excluir(int id);
}