using System.Threading.Tasks;
using Logstore.HungryPizza.Application.Pedidos;

namespace Logstore.HungryPizza.Application.Interfaces
{
    public interface IPedidoAppService
    {
        Task<int> RegistrarNovoPedido(RegistrarNovoPedidoViewModel novoPedido);
    }
}