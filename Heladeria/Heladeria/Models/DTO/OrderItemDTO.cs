using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Heladeria.Models.DTO
{
    public class OrderItemDTO
    {

        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal? UnitPrice { get; set; } = 0;

        public int Quantity { get; set; } = 1;

        public OrderDTO? Order { get; set; }

        public ProductDTO? Product { get; set; }

        public decimal? Subtotal { get; set; } = 0;
    }
}