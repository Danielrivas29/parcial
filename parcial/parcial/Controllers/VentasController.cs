using data.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        public readonly iVentaRepositorio _VentaRepositorio;
        [HttpPost]
        public async Task<IActionResult> InsertVenta([FromBody] ventas ventas)
        {
            if (ventas == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _VentaRepositorio.insertVenta(ventas);
            return Ok(created);
        }
    }
}
