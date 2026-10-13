using Farmacia.Domains.Service.IService;
using Farmacia.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService service) : ControllerBase
{
    private readonly IAuthService _service = service;

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequests request)
    {
        var usuario = await _service.LoginAsync(request);

        return Ok(usuario);
    }

    [HttpPost("Registar")]
    public async Task<IActionResult> RegistarAsync([FromBody] RegistarRequest request)
    {
        var usuario = await _service.RegistrarAsync(request);

        return Ok(usuario);
    }
}