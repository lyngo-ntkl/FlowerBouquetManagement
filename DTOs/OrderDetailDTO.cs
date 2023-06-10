using System;
using System.Collections.Generic;

#nullable disable

namespace DTOs
{
    public partial class OrderDetailDTO
    {
        public int OrderId { get; set; }
        public int FlowerBouquetId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public virtual FlowerBouquetDTO FlowerBouquet { get; set; }
        public virtual Order Order { get; set; }
    }
}
