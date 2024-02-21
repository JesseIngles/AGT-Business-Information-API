using CrudEmpresas.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpresas.DAL.Database;

public class MyDbContext : DbContext
{
    public string Stringconexao = "HOST=http://127.0.0.1; port= 4040;"+
                                "Username=postgres; Database=DbEmpresas;password=1234";
    public DbSet<Empresa> TbEmpresa {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(Stringconexao);
}