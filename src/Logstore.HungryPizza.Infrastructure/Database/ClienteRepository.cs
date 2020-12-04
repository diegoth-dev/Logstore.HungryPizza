using System;
using System.Linq;
using Logstore.HungryPizza.Core.Interfaces;
using System.Threading.Tasks;
using Logstore.HungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logstore.HungryPizza.Infrastructure.Database
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClienteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Cliente> GetHistoricoPedidos(int clienteId)
        {
            try
            {
                var cliente = await _appDbContext.Clientes.Include(x => x.Endereco)
                                                    .Include(x => x.Pedidos)
                                                    .ThenInclude(y => y.PedidoItems)
                                                    .ThenInclude(z => z.Produto)
                                                    .Where(x => x.Id == clienteId).FirstOrDefaultAsync();

                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}