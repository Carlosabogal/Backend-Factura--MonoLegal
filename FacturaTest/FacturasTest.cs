using Facturacion.Controllers;
using Facturacion.Models.Entity;
using Facturacion.Models.Request;
using Facturacion.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FacturaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task InsertarFactura_DebeRetornarOkConMensajeExitoso()
        {
            var facturaServiceMock = new Mock<FacturaService>();
            var controller = new FacturaController(facturaServiceMock.Object);
            var crearFacturaRequest = new CrearFacturaRequest
            {    Id = "1",
                CodigoFactura = "F001",
                Cliente = "Cliente de prueba",
                CorreoElectronico = "cliente@prueba.com",
                Ciudad = "Ciudad de Prueba",
                Desarrollo = "Desarrollo de Prueba",
                NumeroBogota = "12345",
                NIT = "1234567890",
                SubTotal = 100.00m,
                Iva = 16.00m,
                Retencion = "Retención de Prueba",
                RetencionValor = 5.00m,
                FechaCreacion = DateTime.Now,
                Pagada = false
            };


            var result = await controller.InsertarFactura(crearFacturaRequest) as OkObjectResult;


            Assert.AreEqual("Factura insertada con éxito", result.Value);
        }

        [TestMethod]
        public async Task ActualizarFactura(string id, bool pago)
        {

            var facturaServiceMock = new Mock<FacturaService>();
            var controller = new FacturaController(facturaServiceMock.Object);


            var result = await controller.ActualizarFactura("1", true) as OkObjectResult;

            Assert.AreEqual("Factura actualizada con éxito", result.Value);

        }
        [TestMethod]
        public async Task GetAll()
        {

            var facturaServiceMock = new Mock<FacturaService>();
            var controller = new FacturaController(facturaServiceMock.Object);


            var result = await controller.GetAll() as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode); 

        }



    }
}
