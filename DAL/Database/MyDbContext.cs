using CrudEmpresas.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpresas.DAL.Database;

public class MyDbContext : DbContext
{
    private static string Stringconexao = "HOST=localhost; port=5434;" +
                                "Username=postgres; Database=EmpresaDb;password=1234";
    public DbSet<Empresa> TbEmpresa { get; set; }
    public DbSet<EmpresaEmail> TbEmailEmpresa {get;set;}
    public DbSet<EmpresaTelefone> TbTelefoneEmpresa {get;set;}
    public DbSet<Regime> TbRegime {get;set;}
    public DbSet<ActividadeEconomica> TbActividadeEconomica {get;set;}
    public DbSet<Funcionario> TbFuncionario {get;set;}
    public DbSet<FuncionarioEmail> TbFuncionarioEmail {get;set;}
    public DbSet<EmpresaFuncionario> TbEmpresaFuncionario {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(Stringconexao);
}