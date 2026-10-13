using Farmacia.Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace Farmacia.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Produto> Produtos { get; set; }
    
    public DbSet<Venda> Vendas { get; set; }
    
    public DbSet<ItensVenda> ItensVendas { get; set; }
    
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)
            .HasPrecision(18, 2);
        
        modelBuilder.Entity<Venda>().
            Property(p => p.Total)
            .HasPrecision(18, 2);
        
        modelBuilder.Entity<ItensVenda>().
            Property(p => p.PrecoUnitario)
            .HasPrecision(18, 2);
        
        // Vendas -> ItensVenda
        modelBuilder.Entity<ItensVenda>()
            .HasOne(i => i.Venda)
            .WithMany(v => v.Itens)
            .HasForeignKey(i => i.VendaId)
            .OnDelete(DeleteBehavior.Cascade);
    //Produto -> ItensVenda
        modelBuilder.Entity<ItensVenda>()
            .HasOne(i => i.Produto)
            .WithMany(p => p.ItensVenda)
            .HasForeignKey(i => i.ProdutoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}