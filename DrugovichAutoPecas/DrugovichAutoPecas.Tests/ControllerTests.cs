using AutoMapper;
using DrugovichAutoPecas.API.Contracts;
using DrugovichAutoPecas.API.Controllers;
using DrugovichAutoPecas.API.DTO;
using DrugovichAutoPecas.API.Mapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DrugovichAutoPecas.Tests
{
    public class ControllerTests
    {
        private readonly IMapper _mapper;
        private readonly AutoPecasController _controller;
        private Mock<IRepositoryWrapper> _repository;

        public ControllerTests()
        {
            _repository = new Mock<IRepositoryWrapper>();
            var mapperConfig = new MapperConfiguration(
                x =>
                {
                    x.AddProfile(new AutoPecasMapping());
                });
            _mapper = mapperConfig.CreateMapper();
            _controller = new AutoPecasController(_repository.Object, _mapper);
        }


        [Test]
        public async Task AddCliente_RetornoOk()
        {
            var dto = new ClienteDTO
            {
                Cnpj = "11.111.111/1111-11",
                DataFundacao = DateTime.Now,
                IdGrupo = 0,
                Nome = "Cliente1"
            };
            _repository.Setup(c => c.Cliente.GetAllClientesAsync()).Verifiable();
            var result = await _controller.AddCliente(dto);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task AddCliente_RetornoInvalido()
        {
            var dto = new ClienteDTO
            {
                Cnpj = "11111111111",
                DataFundacao = DateTime.Now,
                IdGrupo = 0,
                Nome = "Cliente1"
            };
            _repository.Setup(c => c.Cliente.GetAllClientesAsync()).Verifiable();
            var result = await _controller.AddCliente(dto);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
    }
}