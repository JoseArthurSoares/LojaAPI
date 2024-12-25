using LojaAPI.Models;

namespace LojaAPI.Services;

public interface RelatorioService
{
    Task<List<ProdutoRelatorio>> ObterTopProdutosVendidos();
}