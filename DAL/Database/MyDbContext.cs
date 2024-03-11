using CrudEmpresas.DAL.CRepository;
using CrudEmpresas.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpresas.DAL.Database;

public class MyDbContext : DbContext
{

    public DbSet<Empresa> TbEmpresa { get; set; }
    public DbSet<EmpresaEmail> TbEmailEmpresa {get;set;}
    public DbSet<EmpresaTelefone> TbTelefoneEmpresa {get;set;}
    public DbSet<Regime> TbRegime {get;set;}
    public DbSet<ActividadeEconomica> TbActividadeEconomica {get;set;}
    public DbSet<Funcionario> TbFuncionario {get;set;}
    public DbSet<FuncionarioEmail> TbFuncionarioEmail {get;set;}
    public DbSet<EmpresaFuncionario> TbEmpresaFuncionario {get;set;}
    public DbSet<Cargo> TbCargo {get;set;}
    public DbSet<Agente> TbAgente { get; set; }
    public DbSet<AgenteEmail> TbAgenteEmail {get;set;}
    public DbSet<AgenteTelefone> TbAgenteTelefone {get;set;}
    public DbSet<SectorEconomico> TbSectorEconomico {get;set;}
    public DbSet<TipoEmpresa> TbTipoEmpresa {get;set;}
    public DbSet<Cargo> TbCargo {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("HOST=localhost; port=5434;Username=postgres; Database=EmpresaDb;password=1234");

}