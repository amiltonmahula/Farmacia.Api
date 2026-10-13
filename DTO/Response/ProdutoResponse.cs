namespace Farmacia.DTO.Response;

public record ProdutoResponse(
    Guid Id,
    string Nome,
    decimal Preco,
    int Quantidade,
    DateTime DataValidade,
    string Descricao,
    string CodigoDeBarra,
    DateTime CriadoEm
    );