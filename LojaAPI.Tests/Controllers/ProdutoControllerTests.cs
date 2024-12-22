using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using LojaAPI.Controllers;
using LojaAPI.Repositories;
using LojaAPI.Models;
using LojaAPI.Services;

namespace LojaAPI.Tests.Controllers
{
    public class ProdutoControllerTests
    {
        private readonly Mock<ProdutoService> _mockService;
        private readonly ProdutoController _controller;
        
        public ProdutoControllerTests()
        {
            _mockService = new Mock<ProdutoService>();
            _controller = new ProdutoController(_mockService.Object);
        }
        
        [Fact]
        public async Task Post_ValidProduto_ReturnsCreatedAtAction()
        {
            // Arrange
            var produto = new Produto { ProdutoId = 1, Nome = "Teste" };
            _mockService.Setup(service => service.Inserir(It.IsAny<Produto>()))
                        .ReturnsAsync(produto);
            
            // Act
            var result = await _controller.Post(produto);
            
            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.Get), actionResult.ActionName);
        }
        
        [Fact]
        public async Task Post_InvalidProduto_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Nome", "Campo obrigatório");
            
            // Act
            var result = await _controller.Post(new Produto());
            
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}