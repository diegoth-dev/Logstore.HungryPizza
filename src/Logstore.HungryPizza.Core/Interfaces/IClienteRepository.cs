using System.Threading.Tasks;
using Logstore.HungryPizza.Core.Entities;

namespace Logstore.HungryPizza.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetHistoricoPedidos(int clienteId);
    }
}