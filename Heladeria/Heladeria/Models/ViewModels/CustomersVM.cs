using Microsoft.AspNetCore.Mvc.Rendering;
using Heladeria.Models.DTO;

namespace Heladeria.Models.ViewModels
{
    public class CustomersVM
    {
        public IEnumerable<SelectListItem>? ListCustomers { get; set; }
        public CustomerDTO? Customer { get; set; }

    }
}