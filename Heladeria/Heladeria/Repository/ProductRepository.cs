using Heladeria.Models.DTO;
using Heladeria.Repository.Interfaces;

namespace Heladeria.Repository
{
    public class ProductRepository : Repository<ProductDTO>, IProductRepository
    {
        public ProductRepository(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }
    }
}