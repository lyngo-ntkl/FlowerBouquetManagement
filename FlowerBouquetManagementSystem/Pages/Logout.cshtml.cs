using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FlowerBouquetManagementSystem.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {

        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.Response.Cookies.Delete("CookieSettings");
            //HttpContext.Session.Clear();
            return RedirectToPage("/Index"); 
        }
    }
}
