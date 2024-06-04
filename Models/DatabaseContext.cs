//intermediario entre a linguagem e o banco de dados
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

//parcial classe escria em dois ou mais arquivos(continua em um e termina na outra
public partial class DatabaseContext : DbContext 
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    //virtul(polimorfismo)
    public virtual DbSet<Customer> Customer { get; set; } //se não usar o DbSet o controller não funciona!
    public virtual DbSet<Product> Product{ get; set; }
    public virtual DbSet<ProductCategory> ProductCategory { get; set; }
    public virtual DbSet<SalesOrder> SalesOrder { get; set; }
    public virtual DbSet<SalesOrdemItem> SalesOrdemItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //OnModelCreating cria o banco de dados
    {   //modelBuilder = objeto para configurar o contexto para o banco de dados

        modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
        modelBuilder.Entity<Customer>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.City).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.State).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Latitude).HasPrecision(11,3).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Longitude).HasPrecision(11,3).IsRequired();
        modelBuilder.Entity<Customer>().HasMany<SalesOrder>().WithOne().HasForeignKey(e => e.CustomerId); //hasMany = um para muitos

        modelBuilder.Entity<Product>().HasKey(e => e.ProductId); //HasKey = chave primaria
        modelBuilder.Entity<Product>().Property(p => p.ProductCategoryId);
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(11,5).IsRequired();
        modelBuilder.Entity<Product>().HasMany<SalesOrdemItem>().WithOne().HasForeignKey(e => e.ProductId);

        modelBuilder.Entity<ProductCategory>().HasKey(e => e.ProductCategoryId);
        modelBuilder.Entity<ProductCategory>().Property(ep => ep.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<ProductCategory>().HasMany<Product>().WithOne().HasForeignKey(e => e.ProductCategoryId);

        modelBuilder.Entity<SalesOrder>().HasKey(e => e.OrderId);
        modelBuilder.Entity<SalesOrder>().Property(p => p.CustomerId).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.OrderDate).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.EstimatedDeliveryDate);
        modelBuilder.Entity<SalesOrder>().Property(p => p.Status).HasMaxLength(20).IsRequired();
        modelBuilder.Entity<SalesOrder>().HasMany<SalesOrdemItem>().WithOne().HasForeignKey(e => e.OrderId);

        modelBuilder.Entity<SalesOrdemItem>().HasKey(e => new {e.OrderId, e.ProductId});//new = chave composta das chave e.Order e e.ProductId
        modelBuilder.Entity<SalesOrdemItem>().Property(p => p.Quantity).IsRequired();
        modelBuilder.Entity<SalesOrdemItem>().Property(p => p.UnitPrice).HasPrecision(11,5).IsRequired();

        OnModelCreatingPartial(modelBuilder); //toda vez que vc editar o models, é necessario dar "dotnet ef  database update"
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}