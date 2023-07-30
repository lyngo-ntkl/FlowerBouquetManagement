using System;
using System.Collections.Generic;

#nullable disable

namespace DTOs
{
    public partial class FlowerBouquetDTO
    {
        public FlowerBouquetDTO()
        {
            OrderDetails = new HashSet<OrderDetailDTO>();
        }

        public int FlowerBouquetId { get; set; }
        
        public int CategoryId { get; set; }
        public string FlowerBouquetName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public byte? FlowerBouquetStatus { get; set; }
        public int? SupplierId { get; set; }

        public virtual CategoryDTO Category { get; set; }
        public virtual SupplierDTO Supplier { get; set; }
        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
