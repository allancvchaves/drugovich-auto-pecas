using AutoMapper;
using DrugovichAutoPecas.API.Contracts;
using DrugovichAutoPecas.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugovichAutoPecas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoPecasController : ControllerBase
    {
        private IClienteRepository _autoPecasRepository;
        private readonly IMapper _mapper;

        public AutoPecasController(IClienteRepository autoPecasRepository, IMapper mapper)
        {
            _autoPecasRepository = autoPecasRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            try
            {
                var clientes = await _autoPecasRepository.GetAllClientesAsync();
                var clientesResult = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
                return Ok(clientesResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
