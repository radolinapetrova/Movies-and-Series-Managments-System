using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;

namespace MoviesAndSeriesApplicationWeb.Pages
{
    public class TVShowInfoModel : PageModel
    {
        CPManager cm = new CPManager();

        private List<CinematicProduction> cp = new List<CinematicProduction>();

        [BindProperty]
        public TVShow TV { get { return tv; } }

        string tvName = "";

        public string TVName { get { return tvName; }  }

        public string GetImage(int id)
        {
            return cm.ConvertImage(id);
        }

        private TVShow tv;

        public void OnGet(string name)
        {
            tvName = Request.Query["name"];
            tv = (TVShow)cm.GetCP(name);
        }
    }
}
