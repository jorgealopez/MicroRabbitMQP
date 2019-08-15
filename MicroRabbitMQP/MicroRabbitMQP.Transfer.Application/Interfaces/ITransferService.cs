using System.Collections.Generic;
using MicroRabbitMQP.Transfer.Domain.Models;

namespace MicroRabbitMQP.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}