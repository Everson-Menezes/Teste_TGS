using Microsoft.EntityFrameworkCore;
using Teste_TGS.Models;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    // Adicione outras DbSet para suas entidades aqui, se necessário.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Defina as configurações de mapeamento de entidades, chaves primárias, relações, etc. aqui.
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("AppDb");
        optionsBuilder.UseSqlServer(connectionString);
    }
}
