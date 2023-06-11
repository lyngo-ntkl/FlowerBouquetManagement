using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using Repositories.Implement;
using System.ComponentModel.DataAnnotations;
using BusinessObjects.Models;
using System.Collections.Generic;
using System.Security.Claims;
using BusinessObjects;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

namespace FlowerBouquetManagementSystem.Pages
{
    public class LoginModel : PageModel
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepositoryImpl();
        [BindProperty]
        public Credential CredentialObj { get; set; }
        public Customer Customer { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            // Check whether binding object is valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Verify credential (for admin, customer)
            // create claim to store user information => security context
            // authentication
            // authorization


            if (CredentialObj.Email.Equals(AdminAccountInfo.Email) && CredentialObj.Password.Equals(AdminAccountInfo.Password))
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, CredentialObj.Email),
                    new Claim("Role", "Admin")
                };
                //ClaimsIdentity identity = new ClaimsIdentity(claims, "JwtSettings");
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync("JwtSettings", principal);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return new RedirectResult("/Admin/FlowerBouquetCRUD/Index");
            }

            Customer = _customerRepository.FindCustomerByEmailAndPassword(CredentialObj.Email, CredentialObj.Password);
            if (Customer != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, Customer.Email),
                    new Claim(ClaimTypes.Name, Customer.CustomerName),
                    new Claim("Role", "User")
                };
                //ClaimsIdentity identity = new ClaimsIdentity(claims, "JwtSettings");
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync("JwtSettings", principal);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return new RedirectResult("Index");
            }
            else
            {
                ModelState.AddModelError("NotFound", "Invalid email or password");
            }

            return Page();
        }
    }

    public class Credential
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
