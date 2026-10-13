using Farmacia.Domains.Service.IService;
using Farmacia.DTO.Request;
using Farmacia.DTO.Response;
using Farmacia.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.Controllers;
[ApiController]
[Route("api/venda")]
public class VendaController : ControllerBase
{
    private readonly IVendaService _service;

    public VendaController(IVendaService service)
    {
        _service = service;
    }

    [HttpPost("CriarVenda")]
    public async Task<IActionResult> CriarAsync([FromBody] VendaRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var resultado = await _service.CriarVendaAsync(request);

        return Ok(resultado);
    }

    [HttpGet]
    public async Task<IEnumerable<VendaResponse>> ObterAsync()
    {
        var resultado = await _service.ObterVendaAsync();

        return resultado.Take(15);
    }
}