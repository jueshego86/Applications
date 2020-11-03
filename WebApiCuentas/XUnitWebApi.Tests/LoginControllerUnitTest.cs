using Facade.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;
using WebApi.Servicios.Contrats;
using Xunit;

namespace XUnitWebApi.Tests
{
    public class LoginControllerUnitTest
    {
        [Fact]
        private async void CuandoSeIniciaSesion()
        {
            // arrange
            Mock<IFachadaUsuario> MockFachadaUsuario = new Mock<IFachadaUsuario>();
            Mock<ITokenBuilder> MockTokenBuilder = new Mock<ITokenBuilder>();

            DtoLogin dtoLogin = new DtoLogin
            {
                Nombre = "prueba",
                Password = "xxx"
            };

            Usuario usuario = new Usuario
            {
                Nombre = dtoLogin.Nombre,
                Password = dtoLogin.Password
            };

            MockFachadaUsuario.Setup(f => f.BuscarUsuarioLogin(dtoLogin)).ReturnsAsync(usuario);

            MockTokenBuilder.Setup(t => t.BuildToken(usuario)).Returns(new { token = "eereqwt" });

            LoginController controller = new LoginController(MockFachadaUsuario.Object, MockTokenBuilder.Object); ;

            // act
            var result = await controller.Post(dtoLogin) as OkObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
