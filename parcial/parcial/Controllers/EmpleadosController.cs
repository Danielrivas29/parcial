using data.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        public readonly iEmpleadosRepositorio _EmpleadosRepositorio;
        public EmpleadosController(iEmpleadosRepositorio EmpleadosRepositorio)
        {
            _EmpleadosRepositorio = EmpleadosRepositorio;
        }
        [HttpGet]
        public async Task<IActionResult> getEmpleados()
        {
            return Ok(await _EmpleadosRepositorio.getEmpleados());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getEmpleadosById(int id)
        {
            return Ok(await _EmpleadosRepositorio.getEmpleadosById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertEmpleados([FromBody] empleados empleados)
        {
            if (empleados == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _EmpleadosRepositorio.insertEmpleados(empleados);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmpleados([FromBody] empleados empleados)
        {
            if (empleados == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update = await _EmpleadosRepositorio.updateEmpleados(empleados);
            return Ok(update);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmpleadosById(int id)
        {
            return Ok(await _EmpleadosRepositorio.deleteEmpleados(id));
        }
    }
}
