using Facturacion.Models.Entity;
using Facturacion.Repository.Clients;
using Microsoft.VisualBasic;
using MongoDB.Driver;


namespace Facturacion.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        internal MongoDbClient _repository = new MongoDbClient(); 
        private IMongoCollection<Factura> Collection;
 

        public FacturaRepository(MongoDbClient repository)
        {
            _repository = repository;
            Collection = _repository.db.GetCollection<Factura>("Factura");
        }

        public async Task InsertFactura(Factura factura)
        {
            await Collection.InsertOneAsync(factura);
        }

        public async Task UpdateFactura(Factura factura)
        {
            var filter = Builders<Factura>.Filter.Eq(f => f.Id, factura.Id);
            await Collection.ReplaceOneAsync(filter, factura);
        }

        public async Task DeleteFactura(Factura factura)
        {
            var filter = Builders<Factura>.Filter.Eq(f => f.Id, factura.Id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<Factura> GetFacturaById(string id)
        {
            var filter = Builders<Factura>.Filter.Eq(f => f.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Factura>> GetAll()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
        public async Task DeleteFactura(string id)
        {
            var filter = Builders<Factura>.Filter.Eq(f => f.Id, id);
            await Collection.DeleteOneAsync(filter);
        }

    }
}