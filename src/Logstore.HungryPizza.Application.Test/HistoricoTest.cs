using System.Threading.Tasks;
using Logstore.HungryPizza.Application.Interfaces;
using Logstore.HungryPizza.Application.Test.Database;
using Logstore.HungryPizza.Core.SeedWork;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Logstore.HungryPizza.Application.Test
{
    public class HistoricoTest : IClassFixture<DbFixture>
    {
        private readonly ITestOutputHelper _consoleWriteLine;
        private readonly IRepository _repository;
        private readonly IClienteAppService _clienteAppService;

        public HistoricoTest(DbFixture dbFixture, ITestOutputHelper consoleWriteLine)
        {
            _consoleWriteLine = consoleWriteLine;
            var serviceProvider = dbFixture.ServiceProvider;
            _repository = serviceProvider.GetService<IRepository>();
            _clienteAppService = serviceProvider.GetService<IClienteAppService>();
        }

        [Fact(DisplayName = "Carregar Pedidos Clientes Existentes")]
        public async Task CarregarHistoricoPedidosClientesExistentes()
        {
            //Arrange 
            var clienteId = 3;

            //Act
            var historico = await _clienteAppService.CarregarPedidosCliente(clienteId);

            //Assert
            Assert.True(historico.Pedidos.Count > 0);
        }

        [Fact(DisplayName = "Carregar Pedidos Clientes Inexistentes")]
        public async Task CarregarHistoricoPedidosClientesInexistentes()
        {
            //Arrange 
            var clienteId = 1;

            //Act
            var historico = await _clienteAppService.CarregarPedidosCliente(clienteId);

            //Assert
            Assert.True(historico.Pedidos.Count == 0);
        }
    }
}