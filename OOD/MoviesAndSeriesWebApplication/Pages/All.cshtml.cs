using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;

namespace MoviesAndSeriesApplicationWeb.Pages.Shared
{
    public class AllModel : PageModel
    {

        CPManager cpm = new CPManager();

        private List<CinematicProduction> allCP = new List<CinematicProduction>();

        public string GetImage(int id)
        {
            return cpm.ConvertImage(id);
        }
        public List<CinematicProduction> AllCP { get { return allCP; } }

        public void OnGet(string option)
        {
            allCP = cpm.Productions;
        }
    }
}
