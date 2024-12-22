using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using LojaAPI.Controllers;
using LojaAPI.Models;
using LojaAPI.Services;

namespace LojaAPI.Tests.Controllers
{
    public class ClienteControllerTests
    {
        private readonly Mock<ClienteService> _mockService;
        private readonly ClienteController _controller;

        public ClienteControllerTests()
        {
            _mockService = new Mock<ClienteService>();
            _controller = new ClienteController(_mockService.Object);
        }

        [Fact]
        public async Task Post_ValidCliente_ReturnsCreatedAtAction()
        {
            // Arrange
            var cliente = new Cliente { ClienteId = 1, Nome = "Teste" };
            _mockService.Setup(service => service.Inserir(It.IsAny<Cliente>()))
                        .ReturnsAsync(cliente);

            // Act
            var result = await _controller.Post(cliente);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.Get), actionResult.ActionName);
        }

        [Fact]
        public async Task Post_InvalidCliente_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Nome", "Campo obrigatório");

            // Act
            var result = await _controller.Post(new Cliente());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Get_ReturnsListOfClientes()
        {
            // Arrange
            var clientes = new List<Cliente>
            {
                new Cliente { ClienteId = 1, Nome = "Cliente1" },
                new Cliente { ClienteId = 2, Nome = "Cliente2" }
            };
            _mockService.Setup(service => service.ObterTodos())
                        .ReturnsAsync(clientes);

            // Act
            var result = await _controller.Get();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Cliente>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task GetById_ValidId_ReturnsCliente()
        {
            // Arrange
            var cliente = new Cliente { ClienteId = 1, Nome = "Teste" };
            _mockService.Setup(service => service.ObterPorId(1))
                        .ReturnsAsync(cliente);

            // Act
            var result = await _controller.Get(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Cliente>(actionResult.Value);
            Assert.Equal(1, returnValue.ClienteId);
        }

        [Fact]
        public async Task GetById_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockService = new Mock<ClienteService>();
            mockService.Setup(service => service.ObterPorId(It.IsAny<int>()))
                .ReturnsAsync((Cliente)null); // Retorna null para qualquer ID

            var controller = new ClienteController(mockService.Object);

            // Act
            var result = await controller.Get(-1); // ID inválido

            // Assert
            Assert.IsType<NotFoundObjectResult>(result); // Certifique-se de usar NotFoundObjectResult
            var notFoundResult = result as NotFoundObjectResult;
            Assert.Equal("Cliente não encontrado.", notFoundResult?.Value);
        }


        [Fact]
        public async Task Put_ValidCliente_ReturnsNoContent()
        {
            // Arrange
            var cliente = new Cliente { ClienteId = 1, Nome = "Teste Atualizado" };
            _mockService.Setup(service => service.Atualizar(cliente))
                        .ReturnsAsync(true);

            // Act
            var result = await _controller.Put(cliente);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Put_InvalidCliente_ReturnsNotFound()
        {
            // Arrange
            var cliente = new Cliente { ClienteId = 1, Nome = "Teste Atualizado" };
            _mockService.Setup(service => service.Atualizar(cliente))
                        .ReturnsAsync(false);

            // Act
            var result = await _controller.Put(cliente);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsNoContent()
        {
            // Arrange
            _mockService.Setup(service => service.Excluir(1))
                        .ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockService.Setup(service => service.Excluir(It.IsAny<int>()))
                        .ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(99);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
