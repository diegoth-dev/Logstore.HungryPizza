using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Logstore.HungryPizza.Application.Interfaces;

namespace Logstore.HungryPizza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet, Route("{id}/Pedidos")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var historico = await _clienteAppService.CarregarPedidosCliente(id);
                return Ok(historico);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                throw;
            }
        }
    }
}
