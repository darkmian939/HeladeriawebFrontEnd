using Heladeria.Models.DTO;
using Heladeria.Repository.Interfaces;

namespace Heladeria.Repository;
public class CustomerRepository : Repository<CustomerDTO>, ICustomerRepository
{
    public CustomerRepository(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {

    }
}

