using System.Collections.Generic;
using Logstore.HungryPizza.Core.SeedWork;

namespace Logstore.HungryPizza.Core.Entities
{
    public class Endereco : BaseEntity
    {
        public Endereco()
        {
            Clientes = new HashSet<Cliente>();
            Pedidos = new HashSet<Pedido>();
        }

        public Endereco(string logradouro, string bairro, string numero, string complemento, string municipio, string cep) : this()
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
            Municipio = municipio;
            Cep = cep;
        }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Municipio { get; set; }
        public string Cep { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}