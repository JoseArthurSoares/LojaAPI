using LojaAPI.Models;
using LojaAPI.Repositories;

namespace LojaAPI.Services;


public class ClientePadraoService(IClienteRepository clienteRepository) : ClienteService
{
    public Task<Cliente> Inserir(Cliente cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");
        }
        return clienteRepository.Inserir(cliente);
    }

    public Task<IEnumerable<Cliente>> ObterTodos()
    {
        return clienteRepository.ObterTodos();
    }

    public Task<Cliente?> ObterPorId(int id)
    {
        var cliente = clienteRepository.ObterPorId(id);
        if (cliente == null)
        {
            throw new KeyNotFoundException("Cliente não encontrado.");
        }

        return cliente;
    }

    public Task<bool> Atualizar(Cliente cliente)
    {
        if (clienteRepository.ObterPorId(cliente.ClienteId) == null)
        {
            throw new KeyNotFoundException("Cliente não encontrado.");
        }
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");
        }
        return clienteRepository.Atualizar(cliente);
    }

    public Task<bool> Excluir(int id)
    {
        var cliente = clienteRepository.ObterPorId(id);
        if (cliente == null)
        {
            throw new KeyNotFoundException("Cliente não encontrado.");
        }
        return clienteRepository.Excluir(id);
    }
}