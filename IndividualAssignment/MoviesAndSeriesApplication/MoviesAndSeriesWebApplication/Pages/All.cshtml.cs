using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;
using Entities;
using LogicLayer;
using DataAccessLayer;

namespace MoviesAndSeriesApplicationWeb.Pages.Shared
{
    public class AllModel : PageModel
    {

        CPManager cpm = new CPManager(new MoviesDBManager(), new TVShowDBManager(), new CPDBManager());
        UserManager um = new UserManager(new UserDBM(), new UserDBM());
        WatchlistManager wm = new WatchlistManager(new WatchlistDBManager());

        private User user;

        private IList<CinematicProduction> allCP = new List<CinematicProduction>();

        public string GetImage(int id)
        {
            return cpm.ConvertImage(id);
        }

        public bool WatchlistContains(CinematicProduction cp, string username)
        {
            User user = um.GetUser(username);

            wm.GetWatchlist(user);

            if (wm.ContainMovie(cp, user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public IList<CinematicProduction> AllCP { get { return allCP; } }

        public void OnGet(string option)
        {
            allCP = cpm.Productions;
        }

    }
}
