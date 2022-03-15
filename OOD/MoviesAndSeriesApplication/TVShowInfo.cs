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
    public partial class TVShowInfo : Form
    {
        public TVShowInfo(CinematicProduction pc, Image img)
        {
            InitializeComponent();
            show = (TVShow)pc;
            this.img = img;
        }
        TVShow show;
        Image img;
        private void TVShowInfo_Load(object sender, EventArgs e)
        {
            tbReleaseDate.Text = show.ReleaseDate;
            tbSeasons.Text = show.Seasons.ToString();
            tbName.Text = show.Name;
            tbEpisodes.Text = show.Episodes.ToString();
            rtbDescription.Text = show.Description;
            tbStrPlt.Text = show.StreamingPlatform;
            pbTVShow.Image = img;
            
        }
    }
}
