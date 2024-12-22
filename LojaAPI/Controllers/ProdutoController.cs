using LojaAPI.Models;
using LojaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProdutoController(ProdutoService produtoService) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var produtoCriado = await produtoService.Inserir(produto);
            return CreatedAtAction(nameof(Get), new { id = produtoCriado.ProdutoId }, produtoCriado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var produtos = await produtoService.ObterTodos();
            return Ok(produtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var produto = await produtoService.ObterPorId(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(produto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var produtoAtualizado = await produtoService.Atualizar(produto);
            if (produtoAtualizado == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(produtoAtualizado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var removido = await produtoService.Excluir(id);
            if (!removido)
            {
                return NotFound("Produto não encontrado.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
}