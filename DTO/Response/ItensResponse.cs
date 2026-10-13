namespace Farmacia.DTO.Response;

public record ItensResponse(
    string NomeProduto,
    int Quantidade,
    decimal PrecoUnitario,
    decimal Subtotal);