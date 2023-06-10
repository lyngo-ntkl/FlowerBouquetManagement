using System;
using System.Collections.Generic;

#nullable disable

namespace DTOs
{
    public partial class OrderDTO
    {
        public OrderDTO()
        {
            OrderDetails = new HashSet<OrderDetailDTO>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Total { get; set; }
        public string OrderStatus { get; set; }

        public virtual CustomerDTO Customer { get; set; }
        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
