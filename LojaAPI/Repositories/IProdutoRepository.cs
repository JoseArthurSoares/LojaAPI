using LojaAPI.Models;

namespace LojaAPI.Repositories;

public interface IProdutoRepository
{
    Task<List<Produto>> ObterTodos();
    Task<Produto> ObterPorId(int id);
    Task<Produto> Inserir(Produto produto);
    Task<bool> Atualizar(Produto produto);
    Task<bool> Excluir(int id);
}