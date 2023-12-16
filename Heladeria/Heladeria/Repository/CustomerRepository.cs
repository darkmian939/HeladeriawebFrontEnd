using Heladeria.Models.DTO;
using Heladeria.Repository;
using Heladeria.Repository.Interfaces;

namespace Heladeria.RepositoryInterfaces;
    public class CustomerRepository : Repository<CustomerDTO>, ICustomerRepository
{
    public CustomerRepository(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {

    }
}

