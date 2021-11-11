using Example.Application.Contracts;
using Example.Domain.Entities.Product;
using Example.Infrastructure.Persistence;
using Example.Infrastructure.Repository.BaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Infrastructure.Repository
{
    public class ProductRepository  : Repository<Product>,  IProductRepository
    {
        public ProductRepository(IExampleContext exampleContext) : base(exampleContext) 
        { 
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            return await FilterBy(x => x.Category == categoryName);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await FilterBy(x => x.Name == name);
        }
    }
}
