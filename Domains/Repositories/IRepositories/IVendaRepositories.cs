using Farmacia.Domains.Models;
using Farmacia.DTO.Request;

namespace Farmacia.Domains.Repositories.IRepositories;

public interface IVendaRepositories
{
    Task<IEnumerable<Venda>> ObterAsync();
    Task AdicionarAsync(Venda venda);

    Task SalvarAsync();
}