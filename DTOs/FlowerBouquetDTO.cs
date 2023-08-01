using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DTOs
{
    public partial class FlowerBouquetDTO
    {
        public FlowerBouquetDTO()
        {
            OrderDetails = new HashSet<OrderDetailDTO>();
        }
        // generate by system
        public int FlowerBouquetId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Flower bouquet name is required")]
        [Display(Name = "Flower Bouquet Name")]
        [StringLength(100, ErrorMessage = "Flower bouquet name contains from 5 - 100 characters", MinimumLength = 5)]
        public string FlowerBouquetName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Description contains from 50 - 500 characters", MinimumLength = 50)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Unit price is required")]
        [Display(Name = "Unit Price")]
        [Range(1, double.MaxValue, ErrorMessage = "Unit price is larger than 1")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Units in Stock is required")]
        [Display(Name = "Units in Stock")]
        [Range(0, double.MaxValue, ErrorMessage = "Units in stock is larger than 0")]
        public int UnitsInStock { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        // 1 stands for available, 0 stands for unavailable
        public byte? FlowerBouquetStatus { get; set; }
        public int? SupplierId { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public virtual CategoryDTO Category { get; set; }
        [Required(ErrorMessage = "Supplier is required")]
        [Display(Name = "Supplier")]
        public virtual SupplierDTO Supplier { get; set; }
        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
