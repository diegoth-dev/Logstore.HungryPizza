using System.Collections.Generic;
using Logstore.HungryPizza.Application.Pedidos;
using Logstore.HungryPizza.Core.Entities;

namespace Logstore.HungryPizza.Application.Clientes
{
    public class ClienteViewModel
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public List<PedidoDto> Pedidos { get; set; }

        public ClienteViewModel()
        {
            Pedidos = new List<PedidoDto>();
        }

        public static ClienteViewModel FromCliente(Cliente cliente)
        {
            if(cliente == null)
                return new ClienteViewModel();

            var clienteView = new ClienteViewModel
            {
                ClienteId = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone
            };

            foreach (var clientePedido in cliente.Pedidos)
            {
                var pedido = new PedidoDto
                {
                    PedidoId = clientePedido.Id, 
                    ItemPedido = new List<PedidoItemDto>()
                };

                foreach (var pedidoItem in clientePedido.PedidoItems)
                {
                    var item = new PedidoItemDto
                    {
                        ProdutoId = pedidoItem.IdProduto,
                        DescricaoProduto = pedidoItem.Produto.Descricao,
                        Quantidade = pedidoItem.QtdItem,
                        ValorUnitario = pedidoItem.VlUnitario,
                        Referencia = pedidoItem.Referencia
                    };

                    pedido.ItemPedido.Add(item);
                }

                clienteView.Pedidos.Add(pedido);
            }

            return clienteView;
        }
    }
}