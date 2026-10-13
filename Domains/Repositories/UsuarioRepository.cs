using Farmacia.Data;
using Farmacia.Domains.Models;
using Farmacia.Domains.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Farmacia.Domains.Repositories;

public class UsuarioRepository : BaseRepository,IUsuarioRepository
{
    public UsuarioRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Usuario> AdicionarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
        
        return usuario;
    }

    public async Task<Usuario?> GetByEmailAsync(string email)
        => await _context.Usuarios.FirstOrDefaultAsync(e => e.Email == email);

    public async Task<bool> ExistEmail(string email)
        => await _context.Usuarios.AnyAsync(u => u.Email == email);

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}