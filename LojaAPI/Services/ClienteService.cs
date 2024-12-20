using LojaAPI.Models;


namespace LojaAPI.Services;
public interface ClienteService
{
    Task<Cliente> Inserir(Cliente cliente);
    Task<IEnumerable<Cliente>> ObterTodos();
    Task<Cliente?> ObterPorId(int id);
    Task<bool> Atualizar(Cliente cliente);
    Task<bool> Excluir(int id);
}