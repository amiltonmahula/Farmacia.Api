using Farmacia.Data;
using Farmacia.Domains.Models;
using Farmacia.Domains.Repositories.IRepositories;
using Farmacia.DTO.Request;
using Microsoft.EntityFrameworkCore;

namespace Farmacia.Domains.Repositories;

public class VendaRepositories : BaseRepository, IVendaRepositories
{
    public VendaRepositories(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Venda>> ObterAsync()
    { 
        return await _context.Vendas
            .Include(v => v.Itens)
            .ToListAsync();
        
    }

    public async Task AdicionarAsync(Venda venda)
    {
        await _context.Vendas.AddAsync(venda);
    }

    public async Task SalvarAsync() => await _context.SaveChangesAsync();
}