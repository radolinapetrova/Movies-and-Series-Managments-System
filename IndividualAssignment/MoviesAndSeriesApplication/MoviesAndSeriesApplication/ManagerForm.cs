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
            tbPassword.Text = um.GetUser(LogInForm.CurrentUser).Password;
            tbEmail.Text = um.GetUser(LogInForm.CurrentUser).Email;
            tbPhoneNumber.Text = um.GetUser(LogInForm.CurrentUser).PhoneNumber;
        }

        UserManager um = new UserManager();
        CPManager cpm = new CPManager();

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
            if (cpm.CheckDate(tbReleaseDate.Text))
            {
                if (cpm.GetByPartialName(tbName.Text).Count == 0)
                {
                    try
                    {
                        if (rbMovie.Checked)
                        {
                            cpm.AddMovie(tbName.Text, rtbDescription.Text, tbReleaseDate.Text, Convert.ToInt32(tbRuntime.Text), Convert.ToInt32(tbBudget.Text), tbStrPlt.Text, pbImage);
                            cpm.GetProductions(lbCinematicPr);

                        }
                        else if (rbTVShow.Checked)
                        {
                            cpm.AddTVShow(tbName.Text, rtbDescription.Text, tbReleaseDate.Text, tbStrPlt.Text, Convert.ToInt32(tbSeasons.Text), Convert.ToInt32(tbEpisodes.Text), pbImage);
                            cpm.GetProductions(lbCinematicPr);
                        }
                    }
                    catch (FormatException ex)
                    {

                        MessageBox.Show("The information that you added is invalid, please check again!");
                    }
                }
                else
                {
                    MessageBox.Show("There already exists a cinematic production with that name!");
                }
            }
            else
            {
                MessageBox.Show("You have entered an invalid date!");
            }
        }

        string cinPr;

        //Displaying the information for the movie/tv show the user chose from the listbox
        private void lbCinematicPr_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = lbCinematicPr.SelectedItem.ToString();
            CinematicProduction cp = cpm.GetCP(selectedItem);
            cinPr = selectedItem;

            tbName.Text = cp.Name;
            tbReleaseDate.Text = cp.ReleaseDate;
            tbStrPlt.Text = cp.StreamingPlatform;
            rtbDescription.Text = cp.Description;
            pbImage.Image = cpm.GetImage(cp.Id);

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
                selectedItem = cinPr;
            }

            CinematicProduction cp = cpm.GetCP(selectedItem);

            if (this.cpm.CheckDate(tbReleaseDate.Text))
            {
                if (cp is Movie)
                {
                    cpm.UpdateMovieInfo((Movie)cp, tbName.Text, rtbDescription.Text, tbStrPlt.Text, tbReleaseDate.Text, Convert.ToInt32(tbRuntime.Text), Convert.ToInt32(tbBudget.Text));
                    this.cpm.GetProductions(lbCinematicPr);
                }
                else if (cp is TVShow)
                {
                    cpm.UpdateTVShowInfo((TVShow)cp, tbName.Text, rtbDescription.Text, tbStrPlt.Text, tbReleaseDate.Text, Convert.ToInt32(tbSeasons.Text), Convert.ToInt32(tbEpisodes.Text));
                    this.cpm.GetProductions(lbCinematicPr);
                }
            }
            else
            {
                MessageBox.Show("You have entered an invalid date!");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cpm.GetProductions(lbCinematicPr);
        }

        private void btnShowMovies_Click(object sender, EventArgs e)
        {
            cpm.GetMovies(lbCinematicPr);
        }

        private void btnShowShows_Click(object sender, EventArgs e)
        {
            cpm.GetTVshows(lbCinematicPr);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            cpm.GetByName(lbCinematicPr, tbSearch.Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            cpm.ChooseImage(pbImage);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInForm form = new LogInForm();
            form.ShowDialog();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            um.EditInfo(um.GetUser(LogInForm.CurrentUser).Id, tbUsername.Text, tbPassword.Text, tbEmail.Text, tbPhoneNumber.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbCinematicPr.SelectedIndex > -1)
            {
                string name = lbCinematicPr.SelectedItem.ToString();
                CinematicProduction cp = cpm.GetCP(name);

                cpm.RemoveCP(cp.Id);
                this.cpm.GetProductions(lbCinematicPr);

            }
            else
            {
                MessageBox.Show("Please choose a movie from the list!");
            }
        }
    }
}
