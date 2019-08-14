using MicroRabbit.Infra.Bus;
using MicroRabbitMQP.Banking.Application.Interfaces;
using MicroRabbitMQP.Banking.Application.Services;
using MicroRabbitMQP.Banking.Data.Context;
using MicroRabbitMQP.Banking.Data.Repository;
using MicroRabbitMQP.Banking.Domain.Interfaces;
using MicroRabbitMQP.Domain.Core.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQPBus>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}