using Logstore.HungryPizza.Application.SharedKernel;

namespace Logstore.HungryPizza.Application.Pedidos
{
    public class RegistrarNovoPedidoViewModel
    {
        public int? ClienteId { get; set; }
        public EnderecoDto Endereco { get; set; }
        public PedidoDto Pedido { get; set; }

        public RegistrarNovoPedidoViewModel() { }

        public RegistrarNovoPedidoViewModel(int? clienteId, EnderecoDto endereco, PedidoDto pedido)
        {
            ClienteId = clienteId;
            Endereco = endereco;
            Pedido = pedido;
        }
    }
}