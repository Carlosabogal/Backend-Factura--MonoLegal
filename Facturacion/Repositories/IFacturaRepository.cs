using Facturacion.Models.Entity;

namespace Facturacion.Repository
{
    public interface IFacturaRepository
    {
        Task InsertFactura(Factura factura);
       Task UpdateFactura(Factura factura); 
        Task DeleteFactura(Factura factura);
        Task<Factura> GetFacturaById(string id);
        Task<List<Factura>> GetAll();
        Task DeleteFactura(string id);

    }
}
