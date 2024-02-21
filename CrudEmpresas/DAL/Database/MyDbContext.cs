using Microsoft.EntityFrameworkCore;

namespace CrudEmpresas.DAL.Database;

public class MyDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}