using Farmacia.Domains.Models;
using Farmacia.Domains.Repositories.IRepositories;
using Farmacia.Domains.Service.IService;
using Farmacia.DTO.Request;
using Farmacia.DTO.Response;

namespace Farmacia.Domains.Service;

public class ProdutoService(IProdutoRepositories produtoRepositories) : IProdutoService
{
    public async Task<ProdutoResponse> CriarAsync(ProdutoRequest request)
    {
        if (request.DataValidade < DateTime.Now.Date)
            throw new Exception("Não pode cadastrar produto vencido");
        
        if (request.Preco <= 0) 
            throw new Exception("Preço Inválido");

        var produtos = new Produto(request.Nome, request.Preco, request.QuantidadeEstoque, request.DataValidade,
            request.CodigoDeBarra, request.Descricao);

        await produtoRepositories.AdicionarAsync(produtos);
        await produtoRepositories.SalvarAsync();

        return new ProdutoResponse(
            produtos.Id,
            produtos.Nome,
            produtos.Preco,
            produtos.QuantidadeEstoque,
            produtos.DataValidade,
            produtos.Descricao,
            produtos.CodigoDeBarra,
            produtos.CriadoEm);
    }

    public async Task<IEnumerable<ProdutoResponse>> ListarAsync()
    {
        var produtos = await produtoRepositories.ListarAsync();
        
        return produtos.Select(p => new ProdutoResponse(
            p.Id,
            p.Nome,
            p.Preco,
            p.QuantidadeEstoque,
            p.DataValidade,
            p.Descricao,
            p.CodigoDeBarra,
            p.CriadoEm)).ToList().Take(25);
    }

    public async Task<ProdutoResponse> AtualizarAsync(Guid id, ProdutoRequest request)
    {
        var produto = await produtoRepositories.ObterPorIdAsync(id);
        if (produto is null) throw new Exception("Produto não encotrado");
        
        produto.Nome = request.Nome;
        produto.Preco = request.Preco;
        produto.QuantidadeEstoque = request.QuantidadeEstoque;
        produto.DataValidade = request.DataValidade;
        produto.Descricao = request.Descricao;
        produto.CodigoDeBarra = request.CodigoDeBarra;

        try
        {
            produtoRepositories.AtualizarAsync(produto);
            await produtoRepositories.SalvarAsync();

            return new ProdutoResponse(
                produto.Id,
                produto.Nome, 
                produto.Preco, 
                produto.QuantidadeEstoque, 
                produto.DataValidade,
                produto.Descricao, 
                produto.CodigoDeBarra, 
                produto.CriadoEm);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeletarAsync(Guid id)
    {
        var resultado = await produtoRepositories.ObterPorIdAsync(id);
        if (resultado is null)
            throw new Exception("produto não encontrado");

        try
        {
            produtoRepositories.Remover(resultado);
            await produtoRepositories.SalvarAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
