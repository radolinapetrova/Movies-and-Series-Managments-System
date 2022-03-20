using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;

namespace MoviesAndSeriesApplicationWeb.Pages
{
    public class LogInModel : PageModel
    {
       
        public UserManager um = new UserManager();

        
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }



        public void OnGet()
        {
        }

        public IActionResult OnPost(string button)
        {
            if (button == "LogIn")
            {
                if (ModelState.IsValid)
                {
                    if (um.CheckUsername(username))
                    {
                        if (um.CheckPassword(username, password))
                        {

                        }
                        return RedirectToPage("/Index");
                    }
                    return Page();
                }
                MessageBox.Show("All firlds are required");
                return Page();
            }

            return RedirectToPage("/Registration");
        }
        
    }
}
