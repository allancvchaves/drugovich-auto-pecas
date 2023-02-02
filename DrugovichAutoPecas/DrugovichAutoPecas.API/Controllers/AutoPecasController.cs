using AutoMapper;
using DrugovichAutoPecas.API.Contracts;
using DrugovichAutoPecas.API.DTO;
using DrugovichAutoPecas.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace DrugovichAutoPecas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoPecasController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public AutoPecasController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("grupos")]
        public async Task<IActionResult> GetAllGrupos()
        {
            try
            {
                var grupos = await _repository.Grupo.GetAllGruposAsync();
                var gruposResult = _mapper.Map<IEnumerable<GrupoDTO>>(grupos);
                return Ok(gruposResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("gerentes")]
        public async Task<IActionResult> GetAllGerentes()
        {
            try
            {
                var gerentes = await _repository.Gerente.GetAllGerentesAsync();
                var gerentesResult = _mapper.Map<IEnumerable<GerenteDTO>>(gerentes);
                return Ok(gerentesResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("clientes")]
        public async Task<IActionResult> GetAllClientes()
        {
            try
            {
                var clientes = await _repository.Cliente.GetAllClientesAsync();
                var clientesResult = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
                return Ok(clientesResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("grupo")]
        public async Task<IActionResult> AddGrupo([FromBody] GrupoDTO grupoDTO)
        {
            Grupo grupo = _mapper.Map<Grupo>(grupoDTO);
            try
            {
                _repository.Grupo.AddGrupo(grupo);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: \n" + ex);
            }

            return Ok(new
            {
                Grupo = grupo
            });
        }

        [HttpPost]
        [Route("cliente")]
        public async Task<IActionResult> AddCliente([FromBody] ClienteDTO clienteDTO)
        {            
            if (clienteDTO.Id < 0)
                return BadRequest("Identificador de cliente inválido.");
            clienteDTO.Cnpj = Regex.Replace(clienteDTO.Cnpj, @"[^\d]+", string.Empty);
            if (clienteDTO.Cnpj.Length != 14)
                return BadRequest("Número CNPJ inválido.");

            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            try
            {
                _repository.Cliente.AddCliente(cliente);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: \n" + ex);
            }

            return Ok(new
            {
                Cliente = cliente
            });
        }
    }
}
