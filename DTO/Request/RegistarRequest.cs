using Farmacia.Helpers;

namespace Farmacia.DTO.Request;

public record RegistarRequest(
    string Nome, string Email, string Senha, ECargo Cargo);