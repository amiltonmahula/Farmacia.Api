using Farmacia.Data;
using Farmacia.Domains.Models;
using Farmacia.Domains.Repositories.IRepositories;
using Farmacia.Domains.Service.IService;
using Farmacia.DTO.Request;
using Farmacia.DTO.Response;

namespace Farmacia.Domains.Service;

public class VendaService(IVendaRepositories venda, IProdutoRepositories produto, AppDbContext context)
    : IVendaService
{
    public async Task<VendaResponse> CriarVendaAsync(VendaRequest requerido)
    {
        using var transacao = await context.Database.BeginTransactionAsync();

        var vendas = new Venda();

        foreach (var item in requerido.Itens)
        {
            var prod = await produto.ObterPorIdAsync(item.ProdutoId);
            if (prod is null) 
                throw new Exception("Produto não encontrado");
            if (prod.QuantidadeEstoque < item.Quantidade)
                throw new Exception("Estoque insuficiente");
            if (prod.DataValidade < DateTime.Now)
                throw new Exception($"Vencido: {prod.Nome}");

            prod.QuantidadeEstoque -= item.Quantidade;

            produto.AtualizarAsync(prod);
            
            vendas.Itens.Add(new ItensVenda
            {
                ProdutoId = prod.Id,
                Quantidade = item.Quantidade, 
                PrecoUnitario = prod.Preco
            });
        }

        vendas.Total = vendas.Itens.Sum(i => i.Subtotal);
        await venda.AdicionarAsync(vendas);
        await venda.SalvarAsync();
        await transacao.CommitAsync();

        return new VendaResponse(
            vendas.Id,
            vendas.CriadoEm,
            vendas.Total,
            vendas.Itens
        );
    }

    public async Task<IEnumerable<VendaResponse>> ObterVendaAsync()
    {
        var vendas = await venda.ObterAsync();

        return vendas.Select(v => new VendaResponse(
            v.Id,
            v.CriadoEm,
            v.Total,
            v.Itens
            ));
    }
}