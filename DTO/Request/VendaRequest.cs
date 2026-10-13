namespace Farmacia.DTO.Request;

public sealed record VendaRequest(
    IList<ItensRequest> Itens
    );
    