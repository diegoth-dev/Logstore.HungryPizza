using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Logstore.HungryPizza.Application.Interfaces;
using Logstore.HungryPizza.Application.Pedidos;

namespace Logstore.HungryPizza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoAppService _pedidoAppService;

        public PedidoController(IPedidoAppService pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RegistrarNovoPedidoViewModel novoPedidoViewModel)
        {
            try
            {
                var pedidoId = await _pedidoAppService.RegistrarNovoPedido(novoPedidoViewModel);
                return Ok(pedidoId);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                throw;
            }
        }
    }
}
