using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;
using LogicLayer;

namespace MoviesAndSeriesWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        CPManager cpm = new CPManager(new MoviesDBManager(), new TVShowDBManager(), new CPDBManager());
        //WatchlistManager wm = new WatchlistManager();

        string user = "";

        [BindProperty]
        public string User { get; }


        public string GetImage(int id)
        {
            return cpm.ConvertImage(id);
        }
       

        public void OnGet(int id)
        {
            cpm.Sort("release_date", "DESC");
            newestCP = cpm.Productions;
            //watchlist = wm.GetWatchlist(id);

        }

        public System.Windows.Forms.HtmlElementCollection Images { get; }

        private IList<CinematicProduction> newestCP = new List<CinematicProduction>();
        private List<string> watchlist = new List<string>();

        public IList<CinematicProduction> NewestCP { get { return newestCP; } }
        public IList<string> Watchlist { get { return watchlist; } }


    }
}