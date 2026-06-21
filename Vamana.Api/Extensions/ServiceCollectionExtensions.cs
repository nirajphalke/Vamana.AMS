using Microsoft.EntityFrameworkCore;
using Vamana.AMS.Core.Interfaces;
using Vamana.AMS.Infrastructure.Data;
using Vamana.AMS.Infrastructure.Repositories;
using Vamana.AMS.Services.Students;
using Vamana.AMS.Services.Students.Interfaces;

namespace Vamana.AMS.Api.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyApplicationServices(this IServiceCollection services)
    {
        // Repositories & Services
        services.AddScoped(typeof(IMasterRepository<>), typeof(MasterRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentService, StudentService>();

        // ... more service registrations

        return services;
    }

    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, string connectionString)
    {
        // Register database-related services, potentially taking configuration
        services.AddDbContext<MasterDbContext>(options => options.UseSqlServer(connectionString));
        services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
