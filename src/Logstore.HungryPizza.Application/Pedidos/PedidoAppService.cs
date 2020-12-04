using System;
using System.Linq;
using System.Threading.Tasks;
using Logstore.HungryPizza.Application.Interfaces;
using Logstore.HungryPizza.Core.Entities;
using Logstore.HungryPizza.Core.SeedWork;

namespace Logstore.HungryPizza.Application.Pedidos
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IRepository _repository;
        public PedidoAppService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> RegistrarNovoPedido(RegistrarNovoPedidoViewModel novoPedido)
        {
            try
            {
                Pedido pedido = new Pedido();
                await AdicionarEnderecoNoPedido(novoPedido, pedido);

                foreach (var itemPedido in novoPedido.Pedido.ItemPedido)
                {
                    pedido.AdicionarItensDoPedido(itemPedido.ProdutoId, itemPedido.Quantidade, itemPedido.ValorUnitario, itemPedido.Referencia);
                }

                pedido.AdicionarDadosPedido(novoPedido.Pedido.ItemPedido.Sum(x=> x.Quantidade), novoPedido.Pedido.ValorTotal);

                await _repository.AddAsync(pedido);

                return pedido.Id;
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro no processamento do pedido!");
            }
        }

        private async Task AdicionarEnderecoNoPedido(RegistrarNovoPedidoViewModel novoPedido, Pedido pedido)
        {
            if (novoPedido.ClienteId.HasValue)
            {
                var cliente = await _repository.GetByIdAsync<Cliente>(novoPedido.ClienteId.Value, x=> x.Endereco);
                pedido.IdCliente = cliente.Id;
                pedido.IdEndereco = cliente.IdEndereco;
            }
            else
            {
                pedido.AddEndercoEntrega(novoPedido.Endereco.Logradouro, novoPedido.Endereco.Bairro, novoPedido.Endereco.Numero, novoPedido.Endereco.Complemento, novoPedido.Endereco.Municipio, novoPedido.Endereco.Cep);
            }
        }
    }
}