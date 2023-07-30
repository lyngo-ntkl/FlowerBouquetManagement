using System;
using System.Collections.Generic;
// <<<<<<< HEAD
// =======
// using System.ComponentModel;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// >>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79

#nullable disable

namespace BusinessObjects.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

// <<<<<<< HEAD
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
// =======
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//         public int CustomerId { get; set; }
//         [Required(ErrorMessage = "Email is required")]
//         [MaxLength(100, ErrorMessage = "Maximum characters is 100")]
//         [EmailAddress]
//         public string Email { get; set; }
//         [Required(ErrorMessage = "Name is required")]
//         [MaxLength(180, ErrorMessage = "Maximum characters is 180")]
//         [DisplayName("Name")]
//         public string CustomerName { get; set; }
//         [Required(ErrorMessage = "Email is required")]
//         [MaxLength(15, ErrorMessage = "Maximum characters is 15")]
//         public string City { get; set; }
//         [Required(ErrorMessage = "Email is required")]
//         [MaxLength(15, ErrorMessage = "Maximum characters is 15")]
//         public string Country { get; set; }
//         [Required(ErrorMessage = "Email is required")]
//         [MaxLength(30, ErrorMessage = "Maximum characters is 30")]
// >>>>>>> 3b9f6448989d45199248f460aee90fba0f6e7f79
        public string Password { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
