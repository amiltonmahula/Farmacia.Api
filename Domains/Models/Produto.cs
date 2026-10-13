using System.ComponentModel.DataAnnotations;
using Farmacia.UseCase;

namespace Farmacia.Domains.Models;

public sealed class Produto : BaseEntity
{
    private Produto()
    {
        
    }
    public Produto(string nome, decimal preco, int quantidade, DateTime validade, string? codigoDeBarra, string? descricao )
    {
        Nome = nome;
        Preco = preco;
        QuantidadeEstoque = quantidade;
        DataValidade = validade;
        CodigoDeBarra = codigoDeBarra;
        Descricao = descricao;
    }

    [Required]
    public string Nome { get; set; }
    
    public decimal Preco { get; set; }

    public string? Descricao { get; set; }  

    public int QuantidadeEstoque { get; set; }

    public  DateTime DataValidade { get; set; }

    public string? CodigoDeBarra { get; set; }
    
    //public bool RequerReceita { get; set; }
    
    public ICollection<ItensVenda> ItensVenda { get; set; } = new List<ItensVenda>();
}
