using Heladeria.Models.DTO;

namespace Heladeria.Repository.Interfaces;
    public class CustomerRepository : Repository<CustomerDTO>, ICustomerRepository
{
    public CustomerRepository(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {

    }
}

