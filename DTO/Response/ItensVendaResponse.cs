namespace Farmacia.DTO.Response;

public record ItensResponse(
    Guid ProdutoId,
    string NomeProduto,
    int Quantidade,
    decimal PrecoUnitario,
    decimal Subtotal);