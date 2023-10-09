using Microsoft.AspNetCore.Mvc;
using Cadeterias;
using Cadetes;
using Pedidos;
using Clientes;

namespace Cadeterias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadeteriaController : ControllerBase
    {
    private Cadeteria cadeteria;
    private readonly ILogger<CadeteriaController> logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        cadeteria = Cadeteria.GetInstance();
        this.logger = logger;
    }

        // [GET] api/Cadeteria/GetPedidos
        [HttpGet("GetPedidos")]
        //[Route("Pedidos")]
        public ActionResult<IEnumerable<Pedido>> GetPedidos()
        {
            var pedidos = cadeteria.GetPedidos();
            return Ok(pedidos);
            
        }

        // [GET] api/Cadeteria/GetCadetes
        [HttpGet("GetCadetes")]
        public ActionResult<List<Cadete>> GetCadetes()
        {
            List<Cadete> cadetes = cadeteria.ObtenerCadetes();
            return Ok(cadetes);
        }

        // [PUT] api/Cadeteria/AsignarPedido/{idPedido}/{idCadete}
        [HttpPut("AsignarPedido/{idPedido}/{idCadete}")]
        public IActionResult AsignarPedido(int idPedido, int idCadete)
        {
            try
            {
                cadeteria.AsignarPedido(idPedido, idCadete);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // [PUT] api/Cadeteria/CambiarEstado/{idPedido}/{NuevoEstado}
        [HttpPut("CambiarEstado/{idPedido}/{NuevoEstado}")]
        public IActionResult CambiarEstado(Pedido pedido, int NuevoEstado)
        {
            try
            {
                cadeteria.cambiarEstado(pedido, NuevoEstado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // [PUT] api/Cadeteria/CambiarCadetePedido/{idPedido}/{idNuevoCadete}
        [HttpPut("CambiarCadetePedido/{idPedido}/{idNuevoCadete}")]
        public IActionResult CambiarCadetePedido(int idPedido, string NuevoCadete)
        {
            try
            {
                cadeteria.CambiarCadetePedido(idPedido, NuevoCadete);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}