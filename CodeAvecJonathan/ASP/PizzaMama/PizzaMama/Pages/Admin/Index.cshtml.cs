using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PizzaMama.Pages.Admin
{
    public class IndexModel : PageModel
    {
        IConfiguration configuration;
        public bool failedLogin;

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Pizzas");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string username, string password, string ReturnUrl)
        {
            var AuthSection = configuration.GetSection("Auth");
            if (username == AuthSection["AdminLogin"] && password == AuthSection["AdminPassword"])
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                failedLogin = false;

                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
            }
            failedLogin = true;
            return Page();
        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin");
        }
    }
}
