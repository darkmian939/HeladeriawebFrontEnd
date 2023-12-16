using Heladeria.Models.DTO;
using Heladeria.Repository.Interfaces;

namespace Heladeria.Repository
{
    public class SupplierRepository : Repository<SupplierDTO>, ISupplierRepository
    {
        public SupplierRepository(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }
    }
}