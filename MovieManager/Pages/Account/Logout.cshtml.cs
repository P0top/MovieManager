using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MovieManager.Pages.Account
{
    public class LogoutModel : PageModel
    {
		public async Task<IActionResult> OnPostAsync()
        {
			await HttpContext.SignOutAsync("MyCookieAuth");
			return RedirectToPage("/Index");
        }
    }
}
