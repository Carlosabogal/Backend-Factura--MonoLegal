using Facturacion.Models.Enum;
using Facturacion.Models.Request;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Facturacion.Models.Entity
{
    public class Factura
    {
        [BsonId]
        public string Id { get; set; }

        public string CodigoFactura { get; set; }
        public string Cliente { get; set; }
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        public string Ciudad { get; set; }
        public string Desarrollo { get; set; }
        public string NumeroBogota { get; set; }
        public string NIT { get; set; }
        public decimal TotalFactura { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public string Retencion { get; set; }
        public decimal RetencionValor { get; set; }
        public DateTime FechaCreacion { get; set; }
        [BsonIgnoreIfNull]
        public string Estado { get; set; }
        public bool Pagada { get; set; }
        [BsonIgnoreIfDefault]
        public DateTime FechaPago { get; set; }

        public Factura(CrearFacturaRequest crearFacturaRequest)
        {
            Id = crearFacturaRequest.Id;
            CodigoFactura = crearFacturaRequest.CodigoFactura;
            Cliente = crearFacturaRequest.Cliente;
            CorreoElectronico = crearFacturaRequest.CorreoElectronico;
            Ciudad = crearFacturaRequest.Ciudad;
            Desarrollo = crearFacturaRequest.Desarrollo;
            NumeroBogota = crearFacturaRequest.NumeroBogota;
            NIT = crearFacturaRequest.NIT;
            SubTotal = crearFacturaRequest.SubTotal;
            Iva = crearFacturaRequest.Iva;
            Retencion = crearFacturaRequest.Retencion;
            RetencionValor = crearFacturaRequest.RetencionValor;
            FechaCreacion = crearFacturaRequest.FechaCreacion;
            Estado = EstadosFactura.primerrecordatorio.ToString();
            Pagada = crearFacturaRequest.Pagada;

       

             if (DateTime.Now < FechaCreacion)
                {
                    throw new InvalidOperationException("La fecha de pago no puede ser anterior a la fecha de creación.");
                }
            if (Pagada == true)
            {
                FechaPago = DateTime.Now;


            }
        }
    }



}
