using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;

namespace MoviesAndSeriesApplicationWeb.Pages
{
    public class AccountModel : PageModel
    {

        public UserManager um = new UserManager();

        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string number { get; set; }
        [BindProperty]
        public string password { get; set; }

        public void OnGet()
        {
        }
    }
}
