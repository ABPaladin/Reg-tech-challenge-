using Microsoft.Extensions.DependencyInjection;

namespace Repository;

public static class Setup
{
    public static void SetupRepository(this IServiceCollection services)
    {
        services.AddDbContext<PgContext>();
    }
}