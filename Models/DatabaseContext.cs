//intermediario entre a linguagem e o banco de dados
using Microsoft.EntityFrameworkCore;

//parcial classe escria em dois ou mais arquivos(continua em um e termina na outra
public partial class DatabaseContext : DbContext 
{
    public DatabaseContext(DbContextOptions<DbContext> options) : base(options)
    {

    }

    //virtul(polimorfismo)
    public virtual DbSet <Customer> Customer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   //modelBuilder = objeto para configurar o contexto para o banco de dados
        modelBuilder.Entity<Customer>(entity => {entity.HasKey(k => k.Id);}); //HasKey = chave primaria
        OnModelCreating(modelBuilder);
    }
}