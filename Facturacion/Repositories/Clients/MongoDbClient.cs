using MongoDB.Driver;

namespace Facturacion.Repository.Clients
{
    public class MongoDbClient
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDbClient()
        {

            client = new MongoClient("mongodb://127.0.0.1:27017");
            db = client.GetDatabase("Monolegal");
        }


    }
}
