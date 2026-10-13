using Farmacia.Helpers;
using Farmacia.UseCase;

namespace Farmacia.Domains.Models;

public sealed class Usuario : BaseEntity
{
    public Usuario(string nome, string email, string senha, ECargo cargo)
    {
        Ativo = Ativo;
        Nome = nome;
        Email = email;
        Senha = senha;
        Cargo = cargo;
    }

    private Usuario()
    {
        
    }

    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public ECargo Cargo { get; private set; }
    public bool Ativo { get; set; }
}