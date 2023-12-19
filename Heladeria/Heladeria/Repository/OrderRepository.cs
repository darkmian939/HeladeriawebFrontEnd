using Heladeria.Models.DTO;
using Heladeria.Repository;
using Heladeria.Repository.Interfaces;

namespace Heladeriag.Repository
{
    public class OrderRepository : Repository<OrderDTO>, IOrderRepository
    {
        public OrderRepository(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }
    }
}