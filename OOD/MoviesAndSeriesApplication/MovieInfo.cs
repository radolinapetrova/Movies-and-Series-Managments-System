using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesAndSeriesApplication
{
    public partial class MovieInfo : Form
    {
        public MovieInfo(CinematicProduction cp, Image img)
        {
            InitializeComponent();
            mv = (Movie)cp;
            this.img = img;
        }
        Movie mv;
        Image img;

        private void MovieInfo_Load(object sender, EventArgs e)
        {
            tbName.Text = mv.Name;
            tbBudget.Text = mv.Budget.ToString();
            tbReleaseDate.Text = mv.ReleaseDate.ToString();
            tbRuntime.Text = mv.Runtime.ToString();
            rtbDescription.Text = mv.Description.ToString();
            tbStrPlt.Text = mv.StreamingPlatform;
            pbMovie.Image = img;
        }
    }
}
