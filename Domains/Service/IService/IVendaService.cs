using Farmacia.DTO.Request;
using Farmacia.DTO.Response;

namespace Farmacia.Domains.Service.IService;

public interface IVendaService
{
    Task<VendaResponse> CriarVendaAsync(VendaRequest requerido);

    Task<IEnumerable<VendaResponse>> ObterVendaAsync();
}