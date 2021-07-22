using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microservice.EF.Repositories;
using Microservice.Domain.Contracts.Repositories;
using Microservice.EF.Data;
using Microservice.Domain.Contracts.UnitOfWork;

namespace Microservice.EF.Registers
{
    public static class RepositoryRegister
    {
        public static  IServiceCollection AddRepository(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IEntityRepository, EntityRepository>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddDbContext<EntitiesContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(connectionString));

            return services;
        }
    }
}
