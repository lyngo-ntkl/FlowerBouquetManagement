using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using Repositories.Implement;
using BusinessObjects.Models;
using System.Collections.Generic;
using System.Security.Claims;
using BusinessObjects;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using DTOs;
using System.Linq;

namespace FlowerBouquetManagementSystem.Pages
{
    public class LoginModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;
        public LoginModel(CustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _configuration = configuration;
        }

        [BindProperty]
        public AuthenticationDTO CredentialObj { get; set; }
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


            if (CredentialObj.Email.Equals(_configuration["adminAccount:email"]) && CredentialObj.Password.Equals(_configuration["adminAccount:password"]))
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, CredentialObj.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                //ClaimsIdentity identity = new ClaimsIdentity(claims, "JwtSettings");
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync("JwtSettings", principal);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return new RedirectResult("/Index");
            }

            Customer = _customerRepository.GetAll().Where(x => x.Email.Equals(CredentialObj.Email) && x.Password.Equals(CredentialObj.Password)).SingleOrDefault();
            if (Customer != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, Customer.Email),
                    new Claim(ClaimTypes.Name, Customer.CustomerName),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Sid, Customer.CustomerId.ToString())
                };
                //ClaimsIdentity identity = new ClaimsIdentity(claims, "JwtSettings");
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync("JwtSettings", principal);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return new RedirectResult("/User/FlowerBouquetIndex");
            }
            else
            {
                ModelState.AddModelError("NotFound", "Invalid email or password");
            }

            return Page();
        }
    }
}
