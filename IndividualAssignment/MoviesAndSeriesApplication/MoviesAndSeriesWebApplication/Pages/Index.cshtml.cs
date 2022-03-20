using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;

namespace MoviesAndSeriesWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        CPManager cpm = new CPManager();

        string user = "";

        [BindProperty]
        public string User { get; }


        public string GetImage(int id)
        {
            return cpm.ConvertImage(id);
        }

        private string name;

        [BindProperty]
        public string Name { get; set; }


        public void OnGet()
        {
            newestCP = cpm.Productions;
            cpm.SortDateDesc();
        }

        public System.Windows.Forms.HtmlElementCollection Images { get; }

        private List<CinematicProduction> newestCP = new List<CinematicProduction>();


        public List<CinematicProduction> NewestCP { get { return newestCP; } }


    }
}