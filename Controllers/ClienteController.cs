using API_Cliente_con_EF.Data.Models;
using API_Cliente_con_EF.Dtos;
using API_Cliente_con_EF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Cliente_con_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get() => Ok(await _clienteService.GetAll());


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]    // Si todo va bien
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post(ClienteCreate cliente)
        {

            var cliente_n = new Cliente
            { Correo = cliente.Correo, Nombre = cliente.Nombre, Telefono = cliente.Telefono };

            await _clienteService.Post(cliente_n);
            await _clienteService.Save();
            return Ok(cliente_n);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]    // Si todo va bien
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Patch(ClienteUpdate cliente)
        {
            try
            {
                var updated = await _clienteService.Patch(cliente); // <-- pasar el DTO con los cambios
                if (updated == null) return NotFound();

                await _clienteService.Save(); // Persistir cambios
                return Ok(updated);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]    // Si todo va bien
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var updated = await _clienteService.Delete(id); 
                if (updated == null) return NotFound();

                await _clienteService.Save(); // Persistir cambios
                return Ok(updated);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
