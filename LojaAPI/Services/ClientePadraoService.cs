using LojaAPI.Models;
using LojaAPI.Repositories;

namespace LojaAPI.Services;


public class ClientePadraoService: ClienteService
{
    private readonly IClienteRepository _clienteRepository;
    
    public ClientePadraoService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    public Task<Cliente> Inserir(Cliente cliente)
    {
        return _clienteRepository.Inserir(cliente);
    }

    public Task<IEnumerable<Cliente>> ObterTodos()
    {
        return _clienteRepository.ObterTodos();
    }

    public Task<Cliente?> ObterPorId(int id)
    {
        return _clienteRepository.ObterPorId(id);
    }

    public Task<bool> Atualizar(Cliente cliente)
    {
        return _clienteRepository.Atualizar(cliente);
    }

    public Task<bool> Excluir(int id)
    {
        return _clienteRepository.Excluir(id);
    }
}