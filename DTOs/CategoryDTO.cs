using System;
using System.Collections.Generic;

#nullable disable

namespace DTOs

{
    public partial class CategoryDTO
    {
        public CategoryDTO()
        {
            FlowerBouquets = new HashSet<FlowerBouquetDTO>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<FlowerBouquetDTO> FlowerBouquets { get; set; }
    }
}
