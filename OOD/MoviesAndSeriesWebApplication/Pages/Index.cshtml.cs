using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesAndSeriesApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication.Pages
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
        public string User { get;}



        private string name;
        
        [BindProperty]
        public string Name { get; set; }


        public string GetImage(int id)
        {
            return cpm.ConvertImage(id);
        }


        public System.Windows.Forms.HtmlElementCollection Images { get; }

        private List<CinematicProduction> newestCP = new List<CinematicProduction>();


        public List<CinematicProduction> NewestCP { get { return newestCP; } }
        
        public void OnGet()
        {
            newestCP = cpm.Productions;
            cpm.SortDateDesc();
        }

      
    }
}