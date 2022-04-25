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
    public partial class CPInfo : Form
    {
        public CPInfo(CinematicProduction cp)
        {
            InitializeComponent();
            this.cp = cp;
        }

        CinematicProduction cp;

        private void MovieInfo_Load(object sender, EventArgs e)
        {
            tbName.Text = cp.Name;
            tbReleaseDate.Text = cp.ReleaseDate.ToString();
            rtbDescription.Text = cp.Description.ToString();
            tbStrPlt.Text = cp.StreamingPlatform;
            if (cp.Image != null)
            {
                pbMovie.Image = cp.Image;
            }

            if (cp is Movie)
            {
                Movie mv = (Movie)cp;

                lbl1.Text = "Budget:";
                tb1.Text = "$" + mv.Budget.ToString();
                lbl2.Text = "Runtime:";
                tb2.Text = mv.Runtime.ToString() + " minutes";
            }
            else
            {
                TVShow ts = (TVShow)cp;

                lbl1.Text = "Seasons:";
                tb1.Text = ts.Seasons.ToString();
                lbl2.Text = "Episodes:";
                tb2.Text = ts.Episodes.ToString();
            }
           
        }

        private void btnAddReview_Click(object sender, EventArgs e)
        {

        }
    }
}
