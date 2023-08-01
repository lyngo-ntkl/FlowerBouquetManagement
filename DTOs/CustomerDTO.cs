using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

#nullable disable

namespace DTOs
{
    public partial class CustomerDTO
    {
        public CustomerDTO()
        {
            Orders = new HashSet<OrderDTO>();
        }
        // generate by the system
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "Password contains at least 6 characters")]
        [DataType(DataType.Password)]
        // hash password
        public string Password { get; set; }
        [DataType(DataType.Date)]
        // set minimum age
        public DateTime? Birthday { get; set; }

        public virtual ICollection<OrderDTO> Orders { get; set; }
    }
}
