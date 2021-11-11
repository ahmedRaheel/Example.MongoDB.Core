using Example.Domain.Entities.Product;
using MongoDB.Driver;

namespace Example.Infrastructure.Persistence
{
    public interface IExampleContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoDatabase Database { get; }
    }
}
