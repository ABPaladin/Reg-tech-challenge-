using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Repository;

public partial class PgContext 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost:5432;Database=postgres;Username=postgres;Password=postgres");
    }
}