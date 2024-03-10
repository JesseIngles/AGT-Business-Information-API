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
    public DbSet<Agente> TbAgente { get; set; }
    public DbSet<AgenteEmail> TbAgenteEmail {get;set;}
    public DbSet<AgenteTelefone> TbAgenteTelefone {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
<<<<<<< HEAD

        => optionsBuilder.UseNpgsql("HOST=localhost; port=5434;" +
                                "Username=postgres; Database=EmpresaDb;password=1234");
        => optionsBuilder.UseNpgsql(Stringconexao);

    internal void firstOrDefault(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }

=======
        => optionsBuilder.UseNpgsql("HOST=localhost; port=5434;" +
                                "Username=postgres; Database=EmpresaDb;password=1234");
>>>>>>> 7e557ab7321498070d65e1dcb591417ba3872f83
}