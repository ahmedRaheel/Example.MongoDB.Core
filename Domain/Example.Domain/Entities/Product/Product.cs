using Example.Domain.Common;

namespace Example.Domain.Entities.Product
{
    [BsonCollection("Product")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}