using Farmacia.Helpers;

namespace Farmacia.DTO.Response;

public record UsuarioResponse(
    Guid Id,
    string Nome,
    string Email,
    ECargo Cargo,
    DateTime CriadoEm
    );