using Farmacia.Domains.Models;

namespace Farmacia.Domains.Repositories.IRepositories;

public interface IUsuarioRepository
{
    Task<Usuario> AdicionarAsync(Usuario usuario);
    Task<Usuario?> GetByEmailAsync(string email);
    Task<bool> ExistEmail(string email);
    Task SaveAsync();
}