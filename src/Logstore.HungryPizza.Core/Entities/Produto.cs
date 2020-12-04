using System.Collections.Generic;
using Logstore.HungryPizza.Core.SeedWork;

namespace Logstore.HungryPizza.Core.Entities
{
    public class Produto : BaseEntity
    {
        public Produto()
        {
            PedidoItems = new HashSet<PedidoItem>();
        }

        public string Descricao { get; set; }
        public decimal VlUnitario { get; set; }

        public virtual ICollection<PedidoItem> PedidoItems { get; set; }
    }
}