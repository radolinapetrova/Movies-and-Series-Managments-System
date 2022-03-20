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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            tbUsername.Text = LogInForm.CurrentUser;
            tbPassword.Text = um.GetUser(LogInForm.CurrentUser).Password;
            tbEmail.Text = um.GetUser(LogInForm.CurrentUser).Email;
            tbPhoneNumber.Text = um.GetUser(LogInForm.CurrentUser).PhoneNumber;
        }

        UserManager um = new UserManager();
        CPManager cp = new CPManager();

        

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            cp.GetByName(lbCinematicPr, tbSearch.Text);
        }


        private void lbCinematicPr_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = lbCinematicPr.SelectedItem.ToString();
            CinematicProduction selectedProduction = cp.GetCP(lbCinematicPr.SelectedItem.ToString());

            rtbInfo.Visible = true;
            rtbInfo.Text = cp.GetCP(selectedItem).GetInfo();
            lblReleaseDate.Visible = true;
            tbReleaseDate.Visible = true;
            tbReleaseDate.Text = cp.GetCP(selectedItem).ReleaseDate.ToString();
            lblStreamingPlatform.Visible = true;
            tbStreamingPlatform.Visible = true;
            tbStreamingPlatform.Text = cp.GetCP(selectedItem).StreamingPlatform.ToString();
            btnAdditionalInfo.Visible = true;
        }

        private void btnAdditionalInfo_Click(object sender, EventArgs e)
        {
            CinematicProduction selectedItem = cp.GetCP(lbCinematicPr.SelectedItem.ToString());

            if (selectedItem is Movie)
            {
                MovieInfo newForm = new MovieInfo(selectedItem, cp.GetImage(selectedItem.Id));
                newForm.ShowDialog();

            }
            else if (selectedItem is TVShow)
            {
                cp.GetImage(selectedItem.Id);
                TVShowInfo newForm = new TVShowInfo(selectedItem, cp.GetImage(selectedItem.Id));
                newForm.ShowDialog();

            }

        }

        private void btnShowAll_Click_1(object sender, EventArgs e)
        {
            cp.GetProductions(lbCinematicPr);
        }

        private void cmbFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (cmbFilter.SelectedItem)
            {
                case "Name ASC":
                    cp.Productions.Sort();
                    cp.GetProductions(lbCinematicPr);
                    break;
                case "Name DESC":
                    cp.SortNameDesc();
                    cp.GetProductions(lbCinematicPr);
                    break;
                case "Release date ASC":
                    cp.SortDateAsc();
                    cp.GetProductions(lbCinematicPr);
                    break;
                case "Release date DESC":
                    cp.SortDateDesc();
                    cp.GetProductions(lbCinematicPr);
                    break;
                default:
                    break;
            }
        }

        private void btnShowMovies_Click_1(object sender, EventArgs e)
        {
            cp.GetMovies(lbCinematicPr);
        }

        private void btnShowShows_Click_1(object sender, EventArgs e)
        {
            cp.GetTVshows(lbCinematicPr);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInForm logInForm = new LogInForm();
            logInForm.ShowDialog();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            um.EditInfo(um.GetUser(LogInForm.CurrentUser).Id, tbUsername.Text, tbPassword.Text, tbEmail.Text, tbPhoneNumber.Text);
        }

        
    }
}
