using LojaAPI.Data;
using LojaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Services
{
    public class RelatorioPadraoService(LojaDbContext context) : RelatorioService
    {
        public async Task<List<ProdutoRelatorio>> ObterTopProdutosVendidos()
        {
            var query = @"
                SELECT
                    p.Nome,
                    SUM(ip.Quantidade) as TotalVendido
                FROM
                    ItemPedido ip
                JOIN
                    Produto p ON p.Id = ip.ProdutoId
                GROUP BY
                    p.Nome
                ORDER BY
                    TotalVendido DESC
                LIMIT 10";

            var resultado = await context.Set<ProdutoRelatorio>()
                .FromSqlRaw(query)
                .ToListAsync();
            return resultado;
        }
    }
}