using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;
using Entities;
using LogicLayer;

namespace MoviesAndSeriesApplicationWeb.Pages
{
    public class RegistrationModel : PageModel
    {
        public UserManager um = new UserManager(new UserDBM(), new UserDBM());
        
        [BindProperty]
        public UserDTO UserToCreate { get ; set; }

        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Register();
            }
            return null;
        }


        public IActionResult Register()
        {
            if (!um.CheckUsername(UserToCreate.Username))
            {
                if (um.ConfirmPassword(UserToCreate.Password, UserToCreate.ConfirmPass))
                {
                    if (um.Register(new User(um.GetId(), 1, UserToCreate.Username, um.GetPass(UserToCreate.Password)[1], UserToCreate.Email, UserToCreate.Name, UserToCreate.PhoneNumber, um.GetPass(UserToCreate.Password)[0])))
                    {
                        return RedirectToPage("/LogIn");
                    }
                }
            }
            return null;
        }
    }
}
