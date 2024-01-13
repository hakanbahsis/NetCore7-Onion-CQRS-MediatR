using Api.Persistance.Context;

namespace Api.Persistance;
public static class Registration
{
    public static void AddPersistance(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}

