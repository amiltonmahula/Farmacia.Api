using Farmacia.DTO.Request;
using Farmacia.DTO.Response;

namespace Farmacia.Domains.Service.IService;

public interface IAuthService
{
    Task<string> LoginAsync(LoginRequests login);
    Task<UsuarioResponse> RegistrarAsync(RegistarRequest registarRequest);
}