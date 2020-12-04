using Logstore.HungryPizza.Core.SeedWork;

namespace Logstore.HungryPizza.Core.Entities
{
    public class PedidoItem : BaseEntity
    {
        public PedidoItem() { }

        public PedidoItem(int produtoId, int quantidade, decimal valorUnitario, int? referencia)
        {
            IdProduto = produtoId;
            QtdItem = quantidade;
            VlUnitario = valorUnitario;
            Referencia = referencia;
        }

        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public decimal VlUnitario { get; set; }
        public int QtdItem { get; set; }
        public int? Referencia { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}