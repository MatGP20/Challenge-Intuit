using BackEnd.DataService.Entities;
using BackEnd.DataService.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Challenge.WebAPI.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly IClienteService _clienteService;
        private readonly IValidator<Clientes> _validator;

        public ClienteController(IClienteService clienteService, IValidator<Clientes> validator) 
        {
            _clienteService = clienteService;
            _validator = validator;
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
                var validResult = await _validator.ValidateAsync(newCliente);
                if (validResult.IsValid)
                {
                    var result = await _clienteService.AddNewClienteAsync(newCliente);
                    return result ? Ok(): BadRequest();
                }
                return BadRequest(validResult.Errors);
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
                var validResult = await _validator.ValidateAsync(cliente);
                if (validResult.IsValid)
                {
                    var result = await _clienteService.UpdateClienteAsync(cliente);
                    return result ? Ok() : BadRequest();                    
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
