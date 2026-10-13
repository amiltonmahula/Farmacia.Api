using Farmacia.UseCase;

namespace Farmacia.Domains.Models;

public sealed class Venda : BaseEntity
{
    public decimal Total { get; set; }
    
    // Produtos que fazem parte desta venda
    public ICollection<ItensVenda> Itens { get; set; } = new List<ItensVenda>();
}