using Farmacia.UseCase;

namespace Farmacia.Domains.Models;

public sealed class ItensVenda : BaseEntity
{
    public Guid VendaId { get; set; }
    public Venda Venda { get; set; } = null;
    public Guid ProdutoId { get; set; }
    public Produto Produto { get; set; } = null;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    
    public decimal Subtotal => PrecoUnitario * Quantidade;
}