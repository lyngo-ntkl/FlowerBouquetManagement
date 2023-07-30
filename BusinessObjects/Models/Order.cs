using System;
using System.Collections.Generic;
// <<<<<<< HEAD
// =======
// using System.ComponentModel.DataAnnotations.Schema;
// >>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79

#nullable disable

namespace BusinessObjects.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

// <<<<<<< HEAD
// =======
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
// >>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Total { get; set; }
        public string OrderStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
