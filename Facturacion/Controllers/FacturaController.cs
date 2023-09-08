using Facturacion.Models.Entity;
using Facturacion.Models.Request;
using Facturacion.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaService facturaService)
        {
            _facturaService = facturaService;
        }


        [HttpPost]
        public async Task<IActionResult> InsertarFactura([FromBody] CrearFacturaRequest crearFacturaRequest)
        {
            try
            {
                Factura newFactura = new Factura(crearFacturaRequest);
                await _facturaService.InsertarFactura(newFactura);
                return Ok("Factura insertada con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al insertar factura: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarFactura(string id, bool pago)
        {
            try
            {
                await _facturaService.CambiarEstadoFactura(id, pago);
                return Ok("Factura actualizada con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar factura: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacturaById(string id)
        {
            var factura = await _facturaService.GetFacturaById(id);
            if (factura == null)
            {
                return NotFound();
            }
            return Ok(factura);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var facturas = await _facturaService.GetAll();
            return Ok(facturas);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(string id)
        {
            try
            {
                await _facturaService.DeleteFactura(id);
                return Ok("Factura eliminada con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar la factura: {ex.Message}");
            }
        }
    }

    }
