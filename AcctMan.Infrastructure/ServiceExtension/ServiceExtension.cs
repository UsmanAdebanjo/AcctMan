using AcctMan.Domain.Abstract;
using AcctMan.Domain.Entities;
using AcctMan.Infrastructure.Data;
using AcctMan.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace AcctMan.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIService(this IServiceCollection services)
        {

            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));

            services.AddScoped<ITransactionRepo>(sp =>
            {
                var dbContext = sp.GetRequiredService<AcctManDbContext>();
                var dbSet = dbContext.Set<Transaction>();
                return new TransactionRepo(dbContext, dbSet);
            });

            services.AddScoped<IWalletRepo>(sp =>
            {
                var dbContext = sp.GetRequiredService<AcctManDbContext>();
                var dbSet = dbContext.Set<Wallet>();
                return new WalletRepo(dbContext, dbSet);
            });

            return services;
        }

    }
}
