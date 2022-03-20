using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;

namespace MoviesAndSeriesApplicationWeb.Pages
{
    public class RegistrationModel : PageModel
    {
        public UserManager um = new UserManager();

        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string number { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public string confirmPassword { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (um.Register(username, email, password, name, number))
                {
                    return RedirectToPage("/LogIn");
                }
                return Page();
            }
            MessageBox.Show("All fields are required");
            return Page();
        }
    }
}
