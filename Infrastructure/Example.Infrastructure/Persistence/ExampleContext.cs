using Example.Domain.Entities.Product;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Example.Infrastructure.Persistence
{
    public class ExampleContext : IExampleContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoDatabase Database { get; }

        public ExampleContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("ExampleDatabaseSettings:ConnectionString"));
            Database = client.GetDatabase(configuration.GetValue<string>("ExampleDatabaseSettings:DatabaseName"));
            Products = Database.GetCollection<Product>(configuration.GetValue<string>("ExampleDatabaseSettings:ProductsCollectionName"));
            ExampleContextSeed.SeedData(Products);
        }
    }
}
