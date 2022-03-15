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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
            tbUsername.Text = LogInForm.CurrentUser;
        }

        CPManager manager = new CPManager();

        private void rbMovie_CheckedChanged(object sender, EventArgs e)
        {
            tbEpisodes.Enabled = false;
            tbSeasons.Enabled = false;
            tbRuntime.Enabled = true;
            tbBudget.Enabled = true;
        }

        private void rbTVShow_CheckedChanged(object sender, EventArgs e)
        {
            tbEpisodes.Enabled = true;
            tbSeasons.Enabled = true;
            tbRuntime.Enabled = false;
            tbBudget.Enabled = false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (manager.CheckDate(tbReleaseDate.Text))
            {
                try
                {
                    if (rbMovie.Checked)
                    {
                        manager.AddMovie(tbName.Text, rtbDescription.Text, tbReleaseDate.Text, Convert.ToInt32(tbRuntime.Text), Convert.ToInt32(tbBudget.Text), tbStrPlt.Text, pbImage);
                        manager.GetProductions(lbCinematicPr);

                    }
                    else if (rbTVShow.Checked)
                    {
                        manager.AddTVShow(tbName.Text, rtbDescription.Text, tbReleaseDate.Text, tbStrPlt.Text, Convert.ToInt32(tbSeasons.Text), Convert.ToInt32(tbEpisodes.Text), pbImage);
                        manager.GetProductions(lbCinematicPr);
                    }
                }
                catch (FormatException ex)
                {

                    MessageBox.Show("The information that you added is invalid, please check again!");
                }
            }
            else
            {
                MessageBox.Show("You have entered an invalid date!");
            }

        }

        //Displaying the information for the movie/tv show the user chose from the listbox
        private void lbCinematicPr_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = lbCinematicPr.SelectedItem.ToString();
            CinematicProduction cp = manager.GetCP(selectedItem);

            tbName.Text = cp.Name;
            tbReleaseDate.Text = cp.ReleaseDate;
            tbStrPlt.Text = cp.StreamingPlatform;
            rtbDescription.Text = cp.Description;
            pbImage.Image = manager.GetImage(cp.Id);

            if (cp is TVShow)
            {
                TVShow tvShow = (TVShow)cp;
                tbSeasons.Text = Convert.ToString(tvShow.Seasons);
                tbSeasons.Enabled = true;
                tbEpisodes.Text = Convert.ToString(tvShow.Episodes);
                tbEpisodes.Enabled = true;
                tbRuntime.Text = "";
                tbRuntime.Enabled = false;
                tbBudget.Text = "";
                tbBudget.Enabled = false;
            }
            else if (cp is Movie)
            {
                Movie movie = (Movie)cp;
                tbBudget.Text = Convert.ToString(movie.Budget);
                tbBudget.Enabled = true;
                tbRuntime.Text = Convert.ToString(movie.Runtime);
                tbRuntime.Enabled = true;
                tbEpisodes.Text = "";
                tbEpisodes.Enabled = false;
                tbSeasons.Text = "";
                tbSeasons.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string selectedItem;

            if (lbCinematicPr.SelectedIndex != -1)
            {
                selectedItem = lbCinematicPr.SelectedItem.ToString();
            }
            else
            {
                selectedItem = tbName.Text;
            }

            CinematicProduction cp = manager.GetCP(selectedItem);

            if (manager.CheckDate(tbReleaseDate.Text))
            {
                if (cp is Movie)
                {
                    manager.UpdateMovieInfo((Movie)cp, tbName.Text, rtbDescription.Text, tbStrPlt.Text, tbReleaseDate.Text, Convert.ToInt32(tbRuntime.Text), Convert.ToInt32(tbBudget.Text));
                    manager.GetProductions(lbCinematicPr);
                }
                else if (cp is TVShow)
                {
                    manager.UpdateTVShowInfo((TVShow)cp, tbName.Text, rtbDescription.Text, tbStrPlt.Text, tbReleaseDate.Text, Convert.ToInt32(tbSeasons.Text), Convert.ToInt32(tbEpisodes.Text));
                    manager.GetProductions(lbCinematicPr);
                }
            }
            else
            {
                MessageBox.Show("You have entered an invalid date!");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            manager.GetProductions(lbCinematicPr);
        }

        private void btnShowMovies_Click(object sender, EventArgs e)
        {
            manager.GetMovies(lbCinematicPr);
        }

        private void btnShowShows_Click(object sender, EventArgs e)
        {
            manager.GetTVshows(lbCinematicPr);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            manager.GetByName(lbCinematicPr, tbSearch);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            manager.ChooseImage(pbImage);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInForm form = new LogInForm();   
            form.ShowDialog();
        }
    }
}
