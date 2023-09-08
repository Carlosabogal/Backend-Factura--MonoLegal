using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Facturacion.Models.Request
{
    public class CrearFacturaRequest
    {
        public string Id { get; set; }

        public string CodigoFactura { get; set; }
        public string Cliente { get; set; }

        public string CorreoElectronico { get; set; }

        public string Ciudad { get; set; }
        public string Desarrollo { get; set; }
        public string NumeroBogota { get; set; }
        public string NIT { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public string Retencion { get; set; }
        public decimal RetencionValor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Pagada { get; set; }
    }
}
