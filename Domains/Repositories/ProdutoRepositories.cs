using Farmacia.Data;
using Farmacia.Domains.Models;
using Farmacia.Domains.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Farmacia.Domains.Repositories;

public class ProdutoRepositories : BaseRepository,IProdutoRepositories
{
    public ProdutoRepositories(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Produto>> ListarAsync()
    {
        var resultado = await _context.Produtos.ToListAsync();

        return resultado;
    }

    public async Task AdicionarAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
    }

    public async Task<Produto?> ObterPorIdAsync(Guid id) => await _context.Produtos.FindAsync(id); 

    public void AtualizarAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
    }
    
    public void Remover(Produto produto)
    {
        _context.Produtos.Remove(produto);
    }
    
    public async Task SalvarAsync() => await _context.SaveChangesAsync();
    
}