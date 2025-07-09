using BackEnd.DataService.Entities;
using BackEnd.DataService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Challenge.WebAPI.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService) 
        {
              _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _clienteService.GetAllClientsAsync();
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception) 
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _clienteService.GetClientesByIdAsync(id);
                if(result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Clientes newCliente)
        {
            try
            {
                var result = await _clienteService.AddNewClienteAsync(newCliente);
                if (result)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception) 
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Clientes cliente)
        {
            try
            {
                var result = await _clienteService.UpdateClienteAsync(cliente);
                if (result)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
