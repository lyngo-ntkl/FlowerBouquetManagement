using System;
using System.Collections.Generic;

#nullable disable

namespace DTOs
{
    public partial class SupplierDTO
    {
        public SupplierDTO()
        {
            FlowerBouquets = new HashSet<FlowerBouquetDTO>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<FlowerBouquetDTO> FlowerBouquets { get; set; }
    }
}
