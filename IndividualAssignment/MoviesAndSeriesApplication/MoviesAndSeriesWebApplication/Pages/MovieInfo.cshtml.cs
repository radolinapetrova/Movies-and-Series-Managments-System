using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;
using Microsoft.AspNetCore.Authorization;

namespace MoviesAndSeriesApplicationWeb.Pages
{
    [Authorize]
    public class MovieInfoModel : PageModel
    {

        CPManager cm = new CPManager(new MoviesDBManager(), new TVShowDBManager(), new CPDBManager());


        [BindProperty]
        public Movie MV { get { return mv; } }
        [BindProperty]
        public CinematicProduction CP { get { return cp; } }
        [BindProperty]
        public TVShow TS { get { return ts; } }


        public string GetImage(int id)
        {
            return cm.ConvertImage(id);
        }

        private Movie mv;
        private CinematicProduction cp;
        private TVShow ts;

        
        public void OnGet(string id)
        {

            cp = cm.GetCP(Convert.ToInt32(id));
            if (cp is Movie)
            {
                mv = (Movie)cp;
            }
            else
            {
                ts = (TVShow)cp;
            }
        }

       
    }
}
