using LojaAPI.Models;

namespace LojaAPI.Repositories;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ObterTodos();
    Task<Cliente?> ObterPorId(int id);
    Task<Cliente> Inserir(Cliente cliente);
    Task<bool> Atualizar(Cliente cliente);
    Task<bool> Excluir(int id);
}