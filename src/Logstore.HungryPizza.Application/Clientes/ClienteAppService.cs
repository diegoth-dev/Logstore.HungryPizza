using System.Threading.Tasks;
using Logstore.HungryPizza.Application.Interfaces;
using Logstore.HungryPizza.Core.Entities;
using Logstore.HungryPizza.Core.Interfaces;
using Logstore.HungryPizza.Core.SeedWork;

namespace Logstore.HungryPizza.Application.Clientes
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IRepository _repository;
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService(IRepository repository, IClienteRepository clienteRepository)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteViewModel> CarregarPedidosCliente(int clienteId)
        {

            var cliente = ClienteViewModel.FromCliente(await _clienteRepository.GetHistoricoPedidos(clienteId));

            return cliente;
        }
    }
}