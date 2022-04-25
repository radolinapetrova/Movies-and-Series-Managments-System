using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
using DataAccessLayer;
using Entities;

namespace MoviesAndSeriesApplication
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();


            tbUsername.Text = LogInForm.CurrentUser.Username;
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.Text = LogInForm.CurrentPassword;
            tbPhoneNumber.Text = LogInForm.CurrentUser.PhoneNumber;

            um = new UserManager(new UserDBM(), new UserDBM());
            cp = new CPManager(new MoviesDBManager(), new TVShowDBManager(), new CPDBManager());
            wm = new WatchlistManager(new WatchlistDBManager());

            GetWatchlist();
        }

        UserManager um;
        CPManager cp;
        WatchlistManager wm;


        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            lbCinematicPr.Items.Clear();

            if (cp.GetByPartialName(tbSearch.Text).Count > 0)
            {
                foreach (CinematicProduction p in cp.GetByPartialName(tbSearch.Text))
                {
                    lbCinematicPr.Items.Add(p);
                }
            }
            else
            {
                lbCinematicPr.Items.Add("No results");
            }
        }

        CinematicProduction selectedProduction;

        private void lbCinematicPr_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduction = (CinematicProduction)lbCinematicPr.SelectedItem;

            rtbInfo.Visible = true;
            rtbInfo.Text = selectedProduction.GetInfo();
            lblReleaseDate.Visible = true;
            tbReleaseDate.Visible = true;
            tbReleaseDate.Text = selectedProduction.ReleaseDate.ToString();
            lblStreamingPlatform.Visible = true;
            tbStreamingPlatform.Visible = true;
            tbStreamingPlatform.Text = selectedProduction.StreamingPlatform.ToString();
            btnAdditionalInfo.Visible = true;
        }

        private void btnAdditionalInfo_Click(object sender, EventArgs e)
        {
            CPInfo newForm = new CPInfo(selectedProduction);
            newForm.ShowDialog();
        }

        public void GetProductions()
        {
            lbCinematicPr.Items.Clear();

            foreach (CinematicProduction p in cp.Productions)
            {
                lbCinematicPr.Items.Add(p);
            }
        }

        private void btnShowAll_Click_1(object sender, EventArgs e)
        {
            GetProductions();
        }

        public void DisplaySortedCP(string item, string order)
        {
            lbCinematicPr.Items.Clear();

            List<CinematicProduction> sortedProductions = cp.Sort(item, order);

            foreach (CinematicProduction cp in sortedProductions)
            {
                lbCinematicPr.Items.Add(cp);
            }
        }

        private void cmbFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (cmbFilter.SelectedItem)
            {
                case "Name ASC":
                    DisplaySortedCP("name", "ASC");
                    break;
                case "Name DESC":
                    DisplaySortedCP("name", "DESC");
                    break;
                case "Release date ASC":
                    DisplaySortedCP("release_date", "ASC");
                    break;
                case "Release date DESC":
                    DisplaySortedCP("release_date", "DESC");
                    break;
            }
        }

        private void btnShowMovies_Click_1(object sender, EventArgs e)
        {
            lbCinematicPr.Items.Clear();

            foreach (CinematicProduction cp in cp.Productions)
            {
                if (cp is Movie)
                {
                    lbCinematicPr.Items.Add(cp);
                }
            }
        }

        private void btnShowShows_Click_1(object sender, EventArgs e)
        {
            lbCinematicPr.Items.Clear();

            foreach (CinematicProduction cp in cp.Productions)
            {
                if (cp is TVShow)
                {
                    lbCinematicPr.Items.Add(cp);
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInForm logInForm = new LogInForm();
            logInForm.ShowDialog();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            string newPass = um.HashNewPass(tbPassword.Text, LogInForm.CurrentUser);

            if (um.EditInfo(new User(LogInForm.CurrentUser.Id, tbUsername.Text, newPass, tbPhoneNumber.Text)))
            {
                MessageBox.Show("You successfully updated your account information!");
            }
            
        }

        Watchlist watchlist;

        private void GetWatchlist()
        {
            watchlist = wm.GetWatchlist(LogInForm.CurrentUser);

            lbWatchlist.Items.Clear();

            if (watchlist.Productions.Count > 0)
            {
                foreach (CinematicProduction cp in watchlist.Productions)
                {
                    lbWatchlist.Items.Add(cp);
                }
            }
            else
            {
                lbWatchlist.Items.Add("You currently have nothing in your watchlist!");
            }
        }

        private void btnAddWatchlist_Click(object sender, EventArgs e)
        {
            if (wm.AddToWatchlist(LogInForm.CurrentUser, selectedProduction))
            {
                MessageBox.Show("Production successfully added to watchlist!");
                GetWatchlist();
            }
            else
            {
                MessageBox.Show("Production is already addet to the watchlist!");
            }
            
        }

        private void btnRemoveWatchlist_Click(object sender, EventArgs e)
        {
            if (wm.RemoveFromWatchlist(LogInForm.CurrentUser, selectedProduction))
            {
                MessageBox.Show("Production successfully removed from watchlist!");
                GetWatchlist();
            }
        }

        private void lbWatchlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduction = (CinematicProduction)lbWatchlist.SelectedItem;
        }

        int checker = 0;

        private void cpPass_CheckedChanged(object sender, EventArgs e)
        {

            if (checker == 0)
            {
                tbPassword.UseSystemPasswordChar = false;
                tbPassword.PasswordChar = '\0';
                checker++;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
                checker--;
            }
        }
    }
}
