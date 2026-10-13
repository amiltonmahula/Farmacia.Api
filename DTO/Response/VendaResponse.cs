using Farmacia.Domains.Models;

namespace Farmacia.DTO.Response;

public sealed record VendaResponse(
    Guid Id,
    DateTime CriadoEm,
    decimal Total,
    ICollection<ItensVenda> Itens
    );