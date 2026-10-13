namespace Farmacia.DTO.Request;

public record ItensRequest(
    Guid ProdutoId,
    int Quantidade);