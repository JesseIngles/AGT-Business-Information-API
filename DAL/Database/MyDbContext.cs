using CrudEmpresas.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpresas.DAL.Database;

public class MyDbContext : DbContext
{
    public string Stringconexao = "HOST=localhost; port=5434;" +
                                "Username=postgres; Database=EmpresaDb;password=1234";
    public DbSet<Empresa> TbEmpresa { get; set; }
    public DbSet<EmpresaEmail> TbEmailEmpresa {get;set;}
    public DbSet<EmpresaTelefone> TbTelefoneEmpresa {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(Stringconexao);
}