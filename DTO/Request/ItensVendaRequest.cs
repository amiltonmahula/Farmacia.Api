namespace Farmacia.DTO.Request;

public sealed record ItensRequest(
    Guid ProdutoId,
    int Quantidade);