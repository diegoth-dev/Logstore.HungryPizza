using System.Threading.Tasks;
using FluentValidation;
using Logstore.HungryPizza.Core.Entities;
using Logstore.HungryPizza.Core.SeedWork;

namespace Logstore.HungryPizza.Application.Pedidos
{
    public class RegistrarNovoPedidoValidation : AbstractValidator<RegistrarNovoPedidoViewModel>
    {
        private readonly IRepository _repository;
        public RegistrarNovoPedidoValidation(IRepository repository)
        {
            _repository = repository;
            RuleFor(x => x.Pedido.ItemPedido.Count).NotEqual(0).WithMessage("Não há itens no pedido!");
            RuleFor(x => x.Pedido.ItemPedido.Count).Must(x => x <= 10).WithMessage("A quantidade máxima de itens por pedido é 10!");
            RuleFor(x => (x.ClienteId == null || x.ClienteId.Equals(0)) && x.Endereco == null).NotEqual(true).WithMessage("Endereço de entrega obrigatório, para clientes não cadastrados!");
            RuleFor(x => x.ClienteId).MustAsync((clienteId, token) => ClienteExiste(clienteId)).WithMessage("Usuário não encontrado");
        }

        private async Task<bool> ClienteExiste(int? clienteId)
        {
            if (!clienteId.HasValue) return true;

            var usuario = await _repository.GetByIdAsync<Cliente>(clienteId.Value);
            return usuario != null;
        }
    }
}