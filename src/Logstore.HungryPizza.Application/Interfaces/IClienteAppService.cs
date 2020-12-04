using System.Threading.Tasks;
using Logstore.HungryPizza.Application.Clientes;

namespace Logstore.HungryPizza.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<ClienteViewModel> CarregarPedidosCliente(int clienteId);
    }
}