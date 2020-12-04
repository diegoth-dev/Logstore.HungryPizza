using System.Collections.Generic;
using System.Linq;

namespace Logstore.HungryPizza.Application.Pedidos
{
    public class PedidoDto
    {
        public int PedidoId { get; set; }

        public decimal ValorTotal
        {
            get
            {
                var valorMeiaPizza = CalcularMeiaPizza();

                valorMeiaPizza += ItemPedido.Where(x => !x.MeioPedaco).Sum(x => x.ValorUnitario * x.Quantidade);

                return valorMeiaPizza;
            }
        }

        public List<PedidoItemDto> ItemPedido { get; set; }

        public PedidoDto()
        {
            ItemPedido = new List<PedidoItemDto>();
        }

        private decimal CalcularMeiaPizza()
        {
            decimal valorMeiaPizza = 0;
            if (ItemPedido.Any(x => x.MeioPedaco))
            {
                foreach (var referencia in ItemPedido.Where(x => x.MeioPedaco && x.Referencia.HasValue).GroupBy(y => y.Referencia))
                {
                    valorMeiaPizza += ItemPedido.Where(x => x.Referencia.HasValue && x.Referencia.Value.Equals(referencia.Key)).Sum(itemPedido => itemPedido.ValorUnitario / 2);
                }
            }

            return valorMeiaPizza;
        }
    }
}