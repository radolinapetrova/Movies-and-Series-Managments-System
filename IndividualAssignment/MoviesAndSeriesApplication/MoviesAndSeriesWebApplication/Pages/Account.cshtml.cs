using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;

namespace MoviesAndSeriesApplicationWeb.Pages
{
    public class AccountModel : PageModel
    {

        public UserManager um = new UserManager(new UserDBM(), new UserDBM());

        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string number { get; set; }
        [BindProperty]
        public string password { get; set; }

        

        public void OnGet()
        {
        }

        public IActionResult OnPost(string button)
        {
            if (button == "LogOut")
            {
                HttpContext.SignOutAsync();
                HttpContext.Session.Clear();
                return RedirectToPage("/LogIn");
            }
            else
            {
                return Page();
            }
        }
    }
}
