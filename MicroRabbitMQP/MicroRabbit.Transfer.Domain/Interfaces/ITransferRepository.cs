using System.Collections.Generic;
using MicroRabbitMQP.Transfer.Domain.Models;

namespace MicroRabbitMQP.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();

        void Add(TransferLog transferLog);
    }
}