using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;
using Entities;
using LogicLayer;
using DataAccessLayer;


namespace MoviesAndSeriesWebApplication.Pages
{
    [Authorize(Roles = "1")]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        WatchlistManager wm = new WatchlistManager(new WatchlistDBManager());
        UserManager um = new UserManager(new UserDBM(), new UserDBM());
        CPManager cpm = new CPManager(new MoviesDBManager(), new TVShowDBManager(), new CPDBManager());

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public string GetImage(int id)
        {
            return cpm.ConvertImage(id);
        }

        private Watchlist watchlist;

        public  Watchlist Watchlist { get { return watchlist; } }

        public void OnGet()
        {
            watchlist = wm.GetWatchlist(um.GetUser(User.FindFirst("username").Value));
        }
    }
}