using System.Collections.Generic;
using MicroRabbitMQP.Transfer.Data.Context;
using MicroRabbitMQP.Transfer.Domain.Interfaces;
using MicroRabbitMQP.Transfer.Domain.Models;

namespace MicroRabbitMQP.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLogs;
        }

        public void Add(TransferLog transferLog)
        {
            _ctx.TransferLogs.Add(transferLog);
            _ctx.SaveChanges();
        }
    }
}