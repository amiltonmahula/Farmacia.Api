using Farmacia.Domains.Models;
using Farmacia.Domains.Service.IService;
using Farmacia.DTO.Request;
using Farmacia.DTO.Response;
using Farmacia.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.Controllers;
[ApiController]
[Route("api/produto")]
public class ProdutoController(IProdutoService produtoService) : ControllerBase
{
    private readonly IProdutoService _produtoService = produtoService;
    
    [HttpGet]
    public async Task<IEnumerable<ProdutoResponse>> GetProdutos()
    {
        var resultado = await _produtoService.ListarAsync();

        return resultado.Take(20);
    }

    [HttpPost("CriarProduto")]
    public async Task<IActionResult> CreateProduto([FromBody] ProdutoRequest produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
                
        var resultado = await _produtoService.CriarAsync(produto);

        return Ok(resultado);
    }

    
   [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ProdutoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        await _produtoService.AtualizarAsync(id, request);

        return NoContent();
    }

   [HttpDelete("{id}")]
   public async Task<IActionResult> DeletarAsync(Guid id)
   {
       await _produtoService.DeletarAsync(id);
       return NoContent();

   }
}