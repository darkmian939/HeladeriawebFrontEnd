using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heladeria.Models.DTO
{
    public class ProductDTO
    {


        public int Id { get; set; }

        public string ProductName { get; set; }

        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; } = 0;

        public string Package { get; set; }
        public bool IsDiscontinued { get; set; } = false;


    }
}