using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;
using Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MoviesAndSeriesApplicationWeb.Pages
{
    public class LogInModel : PageModel
    {

        public UserManager um = new UserManager(new UserDBM(), new UserDBM());


        [BindProperty]
        public LogInUserDTO LogInUser { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string button)
        {
            if (button == "LogIn")
            {
                return LogIn();
            }
            else
            {
                return RedirectToPage("/Registration");
            }
        }


        //Authentication of the user
        public IActionResult LogIn()
        {
            if (ModelState.IsValid)
            {
                if (um.CheckUsername(LogInUser.Username))
                {
                    if (um.CheckPassword(LogInUser.Username, LogInUser.Password))
                    {
                        SetUpCookie();
                       
                        return RedirectToPage("/Index");
                    }
                }
                return null;
            }

            return null;
        }


        //Setting up 
        public void SetUpCookie()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("username", LogInUser.Username));

            int typeOfAcc = um.GetUser(LogInUser.Username).TypeAcc;
            claims.Add(new Claim(ClaimTypes.Role, typeOfAcc.ToString()));

            claims.Add(new Claim("id", um.GetUser(LogInUser.Username).Id.ToString()));
            claims.Add(new Claim(ClaimTypes.MobilePhone, um.GetUser(LogInUser.Username).PhoneNumber));


            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            });
        }

    }
}
