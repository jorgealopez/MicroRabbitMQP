using MediatR;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbitMQP.Banking.Application.Interfaces;
using MicroRabbitMQP.Banking.Application.Services;
using MicroRabbitMQP.Banking.Data.Context;
using MicroRabbitMQP.Banking.Data.Repository;
using MicroRabbitMQP.Banking.Domain.CommandHandlers;
using MicroRabbitMQP.Banking.Domain.Commands;
using MicroRabbitMQP.Banking.Domain.Interfaces;
using MicroRabbitMQP.Domain.Core.Bus;
using MicroRabbitMQP.Transfer.Application.Interfaces;
using MicroRabbitMQP.Transfer.Application.Services;
using MicroRabbitMQP.Transfer.Data.Context;
using MicroRabbitMQP.Transfer.Data.Repository;
using MicroRabbitMQP.Transfer.Domain.Events;
using MicroRabbitMQP.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQPBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQPBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}