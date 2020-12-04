using System.Collections.Generic;
using Logstore.HungryPizza.Core.SeedWork;

namespace Logstore.HungryPizza.Core.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int? IdEndereco { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}