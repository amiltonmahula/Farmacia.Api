using Farmacia.Domains.Models;

namespace Farmacia.Domains.Repositories.IRepositories;

public interface IProdutoRepositories
{
    Task<IEnumerable<Produto>> ListarAsync();
    Task AdicionarAsync(Produto produto);
    //Task<Produto> BuscarPeloNomeAsync(string nome);
    Task<Produto?> ObterPorIdAsync(Guid id);
    void AtualizarAsync(Produto produto);

    Task SalvarAsync();
    
    void Remover(Produto produto);

}