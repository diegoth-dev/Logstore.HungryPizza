using System;
using System.Collections.Generic;
using Logstore.HungryPizza.Core.SeedWork;

namespace Logstore.HungryPizza.Core.Entities
{
    public class Pedido : BaseEntity
    {
        public Pedido()
        {
            PedidoItems = new HashSet<PedidoItem>();
        }

        public int? IdCliente { get; set; }
        public int? IdEndereco { get; set; }
        public decimal VlTotal { get; set; }
        public int QtdItens { get; set; }
        public DateTime DtPedido { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<PedidoItem> PedidoItems { get; set; }

        public void AddEndercoEntrega(string logradouro, string bairro, string numero, string complemento, string municipio, string cep)
        {
            Endereco = new Endereco(logradouro, bairro, numero, complemento, municipio, cep);
        }

        public void AdicionarItensDoPedido(int produtoId, int quantidade, decimal valorUnitario, int? referencia)
        {
            PedidoItems.Add(new PedidoItem(produtoId, quantidade, valorUnitario, referencia));
        }

        public void AdicionarDadosPedido(int qtdItensPedido, decimal valorTotal)
        {
            DtPedido = DateTime.UtcNow;
            QtdItens = qtdItensPedido;
            VlTotal = valorTotal;
        }
    }
}