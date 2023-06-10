using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class FlowerBouquet
    {
        public FlowerBouquet()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Flower Bouquet ID")]
        public int FlowerBouquetId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Flower bouquet name is required")]
        [DisplayName("Flower Bouquet Name")]
        public string FlowerBouquetName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Unit price is required")]
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Units in stock is required")]
        [DisplayName("Units In Stock")]
        public int UnitsInStock { get; set; }
        [DisplayName("Status")]
        public byte? FlowerBouquetStatus { get; set; }
        public int? SupplierId { get; set; }

        [DisplayName("Category")]
        public virtual Category Category { get; set; }
        [DisplayName("Supplier")]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
