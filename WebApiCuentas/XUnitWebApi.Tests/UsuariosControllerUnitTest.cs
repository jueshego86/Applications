using DataAcces.Contrats;
using Facade;
using Facade.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Moq;
using System;
using System.Collections.Generic;
using WebApi.Controllers;
using Xunit;

namespace XUnitWebApi.Tests
{
    public class UsuariosControllerUnitTest
    {
        private Mock<IAccesoDatosUsuario> MockAccesoDatosUsuario;

        private Mock<IFachadaUsuario> MockFachadaUsuario;

        private Usuario usuario;

        private DtoUsuario dtoUsuario;

        public UsuariosControllerUnitTest()
        {
            this.MockAccesoDatosUsuario = new Mock<IAccesoDatosUsuario>();

            this.MockFachadaUsuario = new Mock<IFachadaUsuario>();

            this.usuario = new Usuario
            {
                Nombre = "prueba",
                Cuenta = "00000",
                Password = "prueba123",
                Balance = 0,
                Admin = false
            };

            this.dtoUsuario = new DtoUsuario
            {
                Nombre = "prueba",
                Cuenta = "00000",
                Password = "prueba123",
                Balance = 0,
                Admin = false
            };
        }

        [Fact]
        public async void CuandoSeInsertaUnUsuario()
        {   
            //Arrange
            this.MockFachadaUsuario.Setup(f => f.InsertarUsuario(this.usuario)).ReturnsAsync(this.usuario);

            UsuarioController controller = new UsuarioController(this.MockFachadaUsuario.Object);

            // act
            var result = await controller.Post(dtoUsuario) as OkObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void CuandoSeConsultaTodosLosUsuarios()
        {
            //Arrange
            this.MockFachadaUsuario.Setup(f => f.ListarUsuarios()).ReturnsAsync(new List<Usuario> { this.usuario });

            UsuarioController controller = new UsuarioController(this.MockFachadaUsuario.Object);

            // act
            var result = await controller.Get() as OkObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void CuandoSeActualizaUnUsuario()
        {
            string nombre = "prueba";

            //Arrange
            this.MockFachadaUsuario.Setup(f => f.BuscarUsuario(nombre)).ReturnsAsync(this.usuario);
            this.MockFachadaUsuario.Setup(f => f.ActualizarUsuario(this.usuario)).ReturnsAsync(true);

            UsuarioController controller = new UsuarioController(this.MockFachadaUsuario.Object);

            // act
            var result = await controller.Put(nombre, this.usuario) as OkObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void CuandoSeBorraUnUsuario()
        {
            //Arrange
            string nombre = "prueba";

            this.MockFachadaUsuario.Setup(f => f.EliminarUsuario(nombre)).ReturnsAsync(true);

            UsuarioController controller = new UsuarioController(this.MockFachadaUsuario.Object);

            // act
            var result = await controller.Delete(nombre) as OkObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
