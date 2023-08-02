using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BusinessObjects.Models
{
    public static class FlowerBouquetStatus
    {
        public static byte Available = 1;
        public static byte Unavailable = 0;
    }
    public partial class FlowerBouquet
    {
        public FlowerBouquet()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int FlowerBouquetId { get; set; }
        public int CategoryId { get; set; }
        public string FlowerBouquetName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public byte? FlowerBouquetStatus { get; set; }
        public int? SupplierId { get; set; }

        public virtual Category Category { get; set; }
// =======
//         //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//         [DisplayName("Flower Bouquet ID")]
//         public int FlowerBouquetId { get; set; }
//         public int CategoryId { get; set; }
//         [Required(ErrorMessage = "Flower bouquet name is required")]
//         [DisplayName("Flower Bouquet Name")]
//         [MaxLength(40, ErrorMessage = "Maximum character is 40")]
//         public string FlowerBouquetName { get; set; }
//         [Required(ErrorMessage = "Description is required")]
//         [DisplayName("Description")]
//         [MaxLength(220, ErrorMessage = "Maximum character is 220")]
//         public string Description { get; set; }
//         [Required(ErrorMessage = "Unit price is required")]
//         [DisplayName("Unit Price")]
//         public decimal UnitPrice { get; set; }
//         [Required(ErrorMessage = "Units in stock is required")]
//         [DisplayName("Units In Stock")]
//         public int UnitsInStock { get; set; }
//         [DisplayName("Status")]
//         public byte? FlowerBouquetStatus { get; set; }
//         public int? SupplierId { get; set; }

//         [DisplayName("Category")]
//         public virtual Category Category { get; set; }
//         [DisplayName("Supplier")]
        public virtual Supplier Supplier { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
