using System.ComponentModel.DataAnnotations;

namespace Farmacia.DTO.Request;

public record ProdutoRequest
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Insira um valor")]
    public decimal Preco { get; set; }
    
    [Required(ErrorMessage = "Informe a Quantidade")] 
    public int QuantidadeEstoque { get; set; }
    
    [Required(ErrorMessage = "Informe a data de validade")]
    public DateTime DataValidade { get; set; }
    
    public string? Descricao { get; set; }
    
    public string? CodigoDeBarra { get; set; }
}