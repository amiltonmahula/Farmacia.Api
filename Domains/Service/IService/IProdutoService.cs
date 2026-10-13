using Farmacia.Domains.Models;
using Farmacia.DTO.Request;
using Farmacia.DTO.Response;

namespace Farmacia.Domains.Service.IService;

public interface IProdutoService
{
    Task<ProdutoResponse> CriarAsync(ProdutoRequest request);
    Task<IEnumerable<ProdutoResponse>>ListarAsync();
    Task<ProdutoResponse> AtualizarAsync(Guid id, ProdutoRequest request);
    Task DeletarAsync(Guid id);
}