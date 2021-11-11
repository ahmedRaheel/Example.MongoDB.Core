using Example.Domain.Entities.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Application.Contracts
{
    public interface IProductRepository : IRepository<Product>
    { 
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    }
}
