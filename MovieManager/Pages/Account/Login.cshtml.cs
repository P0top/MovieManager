using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieManager.Models;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace MovieManager.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }
		public async Task<IActionResult> OnPostAsync()
		{
            if (!ModelState.IsValid) return Page();

            //Verify the Admin
            if (User.Username == "admin" && User.Password == "password")
            {
                // creating the security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                    new Claim("Admin", "true")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

			//Verify the User
			if (User.Username == "user" && User.Password == "password")
			{
				// creating the security context
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, "user"),
					new Claim(ClaimTypes.Email, "user@mywebsite.com"),
				};
				var identity = new ClaimsIdentity(claims, "MyCookieAuth");
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

				await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

				return RedirectToPage("/Index");
			}

			return Page();
		}
	}
}
