using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage = "Maximum characters is 100")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(180, ErrorMessage = "Maximum characters is 180")]
        [DisplayName("Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(15, ErrorMessage = "Maximum characters is 15")]
        public string City { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(15, ErrorMessage = "Maximum characters is 15")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(30, ErrorMessage = "Maximum characters is 30")]
        public string Password { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
