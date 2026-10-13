using Farmacia.Domains.Models;
using Farmacia.Domains.Repositories.IRepositories;
using Farmacia.Domains.Service.IService;
using Farmacia.DTO.Request;
using Farmacia.DTO.Response;

namespace Farmacia.Domains.Service;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _repository;
    private readonly IConfiguration _configuration;


    public AuthService(IUsuarioRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    public async Task<string> LoginAsync(LoginRequests login)
    {
        var usuario = await _repository.GetByEmailAsync(login.Email);
        if (usuario == null || !usuario.Ativo)
            throw new UnauthorizedAccessException("Email não encontrado");
        
        return "";
    }

    public async Task<UsuarioResponse> RegistrarAsync(RegistarRequest request)
    {
        if (await _repository.ExistEmail(request.Email))
            throw new Exception("Este Email já está cadastrado");

        var novoUsuario = new Usuario(request.Nome
            ,request.Email, 
            request.Senha, 
            request.Cargo);
        await _repository.AdicionarAsync(novoUsuario);
        await _repository.SaveAsync();
        return new UsuarioResponse(
            novoUsuario.Id,
            novoUsuario.Nome,
            novoUsuario.Email,
            novoUsuario.Cargo,
            novoUsuario.CriadoEm);
    }
}