using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;

namespace MoviesAndSeriesApplicationWeb.Pages
{
    public class MovieInfoModel : PageModel
    {

        CPManager cm = new CPManager();

        private List<CinematicProduction> cp = new List<CinematicProduction>();
        [BindProperty]
        public Movie MV { get { return mv; } }


        string movieName = "";

        public string MovieName { get { return movieName; }  }

        public string GetImage(int id)
        {
            return cm.ConvertImage(id);
        }

        private Movie mv;

        
        public void OnGet(string name)
        {
           movieName = Request.Query["name"];
            mv = (Movie)cm.GetCP(name);
        }

       
    }
}
