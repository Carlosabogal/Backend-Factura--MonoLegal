using Facturacion.Models.Entity;
using Facturacion.Models.Enum;
using Facturacion.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace Facturacion.Service
{
    public class FacturaService
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task InsertarFactura(Factura factura)
        {
            try
            {
                CalcularTotalFactura(factura);

                await _facturaRepository.InsertFactura(factura);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error al insertar factura.", ex);
            }
        }
        public async Task CambiarEstadoFactura(String id, Boolean Pago)
        {
            var facturaInfo = await _facturaRepository.GetFacturaById(id);

            var estadoActual = facturaInfo.Estado;

            if (string.IsNullOrEmpty(id))
            {

                throw new ArgumentNullException(nameof(id), "El ID de la factura no puede ser nulo o vacío.");
            }
            if (facturaInfo == null)
            {
                throw new Exception("Factura no encontrada.");

            }
            if (Pago)
            {
                facturaInfo.Pagada = true;
                facturaInfo.FechaPago = DateTime.Now;
            }
            if (!facturaInfo.Pagada)
            {
                try { 
                if (estadoActual == EstadosFactura.primerrecordatorio.ToString() && !facturaInfo.Pagada)
                {
                    facturaInfo.Estado = EstadosFactura.segundorecordatorio.ToString();
                     await SendEmail(facturaInfo.CorreoElectronico, EstadosFactura.primerrecordatorio.ToString(), EstadosFactura.segundorecordatorio.ToString());
                }
                else if (estadoActual == EstadosFactura.segundorecordatorio.ToString() && !facturaInfo.Pagada)
                {
                    facturaInfo.Estado = EstadosFactura.desactivado.ToString();
                    await SendEmail(facturaInfo.CorreoElectronico, EstadosFactura.segundorecordatorio.ToString(), EstadosFactura.desactivado.ToString());

                }
                else if (estadoActual == EstadosFactura.desactivado.ToString() && !facturaInfo.Pagada)
                {
                    throw new Exception("La factura esta desactivada , es su ultimo aviso");

                }
                }catch(Exception e)
                {
                    throw new Exception("Hubo en erro en: " +e);
                }

            }
           await _facturaRepository.UpdateFactura(facturaInfo);

        }
        public async Task<Factura> GetFacturaById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "El argumento 'id' no puede ser nulo.");
            }

            return await _facturaRepository.GetFacturaById(id);
        }


        public async Task<List<Factura>> GetAll()
        {
            try
            {
                return await _facturaRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las facturas.", ex);
            }
        }
        public async Task DeleteFactura(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID de factura no válido");
            }

            await _facturaRepository.DeleteFactura(id);
        }
        public async Task SendEmail(string destinationEmail, string primerEstado, string segundoEstado)
        {
            string email = "monolegaltest@outlook.com";
            string pwd = "Monolegal#123";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(email, pwd)
            };

            await client.SendMailAsync(
                new MailMessage(from: email,
                to: destinationEmail,
                subject: "Cambio de estado - Factura pendiente",
                body: $"Su factura se encontraba en el estado {primerEstado}, pero a partir de ahora pasará a estar en estado {segundoEstado}."));
        }


        private void CalcularTotalFactura(Factura factura)
        {
            factura.TotalFactura = factura.SubTotal + factura.Iva - factura.RetencionValor;
        }
    }
}
