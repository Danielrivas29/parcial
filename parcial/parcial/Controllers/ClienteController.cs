using data.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly iClienteRepositorio _clienteRepositorio;
        public ClienteController(iClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        [HttpGet]
        public async Task<IActionResult> getClientes()
        {
            return Ok(await _clienteRepositorio.getClientes());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getClientesById(int id)
        {
            return Ok(await _clienteRepositorio.getClienteById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _clienteRepositorio.insertCliente(cliente);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update = await _clienteRepositorio.updateCliente(cliente);
            return Ok(update);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClienteById(int id)
        {
            return Ok(await _clienteRepositorio.deleteCliente(id));
        }
    }
}
