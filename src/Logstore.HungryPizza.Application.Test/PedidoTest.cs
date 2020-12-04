using System.Collections.Generic;
using System.Threading.Tasks;
using Logstore.HungryPizza.Application.Interfaces;
using Logstore.HungryPizza.Application.Pedidos;
using Logstore.HungryPizza.Application.SharedKernel;
using Logstore.HungryPizza.Application.Test.Database;
using Logstore.HungryPizza.Core.Entities;
using Logstore.HungryPizza.Core.SeedWork;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Logstore.HungryPizza.Application.Test
{
    public class PedidoTest : IClassFixture<DbFixture>
    {
        private readonly ITestOutputHelper _consoleWriteLine;
        private readonly IRepository _repository;
        private readonly IPedidoAppService _pedidoAppService;

        public PedidoTest(DbFixture dbFixture, ITestOutputHelper consoleWriteLine)
        {
            _consoleWriteLine = consoleWriteLine;
            var serviceProvider = dbFixture.ServiceProvider;
            _repository = serviceProvider.GetService<IRepository>();
            _pedidoAppService = serviceProvider.GetService<IPedidoAppService>();
        }

        [Fact(DisplayName = "Novo Pedido Cliente Ja Cadastrado")]
        public async Task NovoPedido_ClienteJaCadastrado()
        {
            //Arrange
            var clienteId = 3;
            var endereco = new EnderecoDto("Rua 2 ", "Grande Vitoria", "2", "Casa", "Vitoria", "29000000");
            var produto = await _repository.GetByIdAsync<Produto>(4);
            var pedido = new PedidoDto
            {
                ItemPedido = new List<PedidoItemDto> {new PedidoItemDto(produto.Id, 1, produto.VlUnitario, null)}
            };

            var novoPedido = new RegistrarNovoPedidoViewModel(clienteId, endereco, pedido);

            //Act
            var result = await _pedidoAppService.RegistrarNovoPedido(novoPedido);

            //Assert
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "Novo Pedido Cliente Sem Cadastro")]
        public async Task NovoPedido_ClienteSemCadastro()
        {
            //Arrange
            var endereco = new EnderecoDto("Rua 2 ", "Grande Vitoria", "2", "Casa", "Vitoria", "29000000");
            var produto = await _repository.GetByIdAsync<Produto>(5);
            var pedido = new PedidoDto
            {
                ItemPedido = new List<PedidoItemDto> { new PedidoItemDto(produto.Id, 1, produto.VlUnitario, null) }
            };

            var novoPedido = new RegistrarNovoPedidoViewModel(null, endereco, pedido);

            //Act
            var result = await _pedidoAppService.RegistrarNovoPedido(novoPedido);

            //Assert
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "Novo Pedido Cliente Sem Cadastro Endereco Entrega Obrigatorio")]
        public void NovoPedido_ClienteSemCadastroEnderecoEntregaObrigatorio()
        {
            //Arrange
            var pedido = new PedidoDto
            {
                ItemPedido = new List<PedidoItemDto> { new PedidoItemDto() }
            };

            var novoPedido = new RegistrarNovoPedidoViewModel(null, null, pedido);

            //Act
            var validation = new RegistrarNovoPedidoValidation(_repository);
            var result = validation.Validate(novoPedido);

            foreach (var error in result.Errors)
            {
                _consoleWriteLine.WriteLine(error.ErrorMessage);
            }
            
            //Assert
            Assert.True(!result.IsValid);
        }

        [Fact(DisplayName = "Novo Pedido Cliente Inválido")]
        public void NovoPedido_ClienteInvalido()
        {
            //Arrange
            var pedido = new PedidoDto
            {
                ItemPedido = new List<PedidoItemDto> { new PedidoItemDto() }
            };

            var novoPedido = new RegistrarNovoPedidoViewModel(1, null, pedido);

            //Act
            var validation = new RegistrarNovoPedidoValidation(_repository);
            var result = validation.Validate(novoPedido);

            foreach (var error in result.Errors)
            {
                _consoleWriteLine.WriteLine(error.ErrorMessage);
            }

            //Assert
            Assert.True(!result.IsValid);
        }

        [Fact(DisplayName = "Validar Mínimo de Itens")]
        public void ValidaQuantidadeMinimaDeItens()
        {
            //Arrange
            var pedido = new PedidoDto();
            var novoPedido = new RegistrarNovoPedidoViewModel(null, new EnderecoDto(), pedido);

            //Act
            var validation = new RegistrarNovoPedidoValidation(_repository);
            var result = validation.Validate(novoPedido);

            foreach (var error in result.Errors)
            {
                _consoleWriteLine.WriteLine(error.ErrorMessage);
            }

            //Assert
            Assert.True(!result.IsValid);
        }

        [Fact(DisplayName = "Validar Máximo de Itens")]
        public void ValidaQuantidadeMaximaDeItens()
        {
            //Arrange
            var pedido = new PedidoDto();
            for (int i = 0; i < 11; i++)
            {
                pedido.ItemPedido.Add(new PedidoItemDto());
            }

            var novoPedido = new RegistrarNovoPedidoViewModel(null, new EnderecoDto(), pedido);

            //Act
            var validation = new RegistrarNovoPedidoValidation(_repository);
            var result = validation.Validate(novoPedido);

            foreach (var error in result.Errors)
            {
                _consoleWriteLine.WriteLine(error.ErrorMessage);
            }

            //Assert
            Assert.True(!result.IsValid);
        }
    }
}
