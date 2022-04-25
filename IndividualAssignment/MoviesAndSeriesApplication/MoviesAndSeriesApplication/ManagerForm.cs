using MoviesAndSeriesApplication.Properties;
using LogicLayer;
using Entities;

namespace MoviesAndSeriesApplication
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();

            //Displaying the account information of the current user in the account tab
            tbUsername.Text = LogInForm.CurrentUser.Username;
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.Text = LogInForm.CurrentPassword;
            tbPhoneNumber.Text = LogInForm.CurrentUser.PhoneNumber;

            //Objects for all the logic manager classes
            um = new UserManager(new UserDBM(), new UserDBM());
            cpm = new CPManager(new MoviesDBManager(), new TVShowDBManager(), new CPDBManager());
            fc = new FactoryClass(new MoviesDBManager(), new TVShowDBManager(), new CPDBManager());

            GetUsers();
        }

        UserManager um;
        CPManager cpm;
        FactoryClass fc;


        //Method for (re)loading all the users in the listbox
        public void GetUsers()
        {
            foreach (User user in um.Users)
            {
                if (user.TypeAcc == 1)
                {
                    lbUsers.Items.Add(user);
                }
            }
        }
        
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

        //Method for (re)loading all the cinematic productions in the listbox
        public void GetProductions()
        {
            lbCinematicPr.Items.Clear();

            foreach (CinematicProduction p in cpm.Productions)
            {
                lbCinematicPr.Items.Add(p);
            }
        }

        //Adding a new cinematic production 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Checking if the entered date is valid
            if (cpm.CheckDate(tbReleaseDate.Text))
            {
                try
                {
                    if (tbName.Text != String.Empty && rtbDescription.Text != String.Empty && tbStrPlt.Text != String.Empty)
                    {
                        //Checking which radio button is checked to see what type of cinematic production the user wants to add
                        if (rbMovie.Checked)
                        {
                            if (cpm.AddCP(fc.CreateMovie(0, tbName.Text, rtbDescription.Text, tbReleaseDate.Text, Convert.ToInt32(tbRuntime.Text), Convert.ToDecimal(tbBudget.Text), tbStrPlt.Text, pbImage.Image)))
                            {
                                MessageBox.Show("The movie was added successfully!");
                                GetProductions();
                            }
                        }
                        else if (rbTVShow.Checked)
                        {
                            if (cpm.AddCP(fc.CreateTVShow(0, tbName.Text, rtbDescription.Text, tbReleaseDate.Text, tbStrPlt.Text, Convert.ToInt32(tbSeasons.Text), Convert.ToInt32(tbEpisodes.Text), pbImage.Image)))
                            {
                                GetProductions();
                                MessageBox.Show("The TV Show was successfully added!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("All fields are required");
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

        CinematicProduction cinPr;

        //Displaying the information for the movie/tv show the user chose from the listbox
        private void lbCinematicPr_SelectedIndexChanged(object sender, EventArgs e)
        {
            CinematicProduction cp = (CinematicProduction)lbCinematicPr.SelectedItem;
            cinPr = cp;

            tbName.Text = cp.Name;
            tbReleaseDate.Text = cp.ReleaseDate;
            tbStrPlt.Text = cp.StreamingPlatform;
            rtbDescription.Text = cp.Description;
            if (cp.Image != null)
            {
                pbImage.Image = cp.Image;
            }
            else
            {
                pbImage.Image = Resources.no_image;
            }


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



        private void btnShowAll_Click(object sender, EventArgs e)
        {
            GetProductions();
        }

        private void btnShowMovies_Click(object sender, EventArgs e)
        {
            lbCinematicPr.Items.Clear();

            foreach (CinematicProduction cp in cpm.Productions)
            {
                if (cp is Movie)
                {
                    lbCinematicPr.Items.Add(cp);
                }
            }
        }

        private void btnShowShows_Click(object sender, EventArgs e)
        {
            lbCinematicPr.Items.Clear();

            foreach (CinematicProduction cp in cpm.Productions)
            {
                if (cp is TVShow)
                {
                    lbCinematicPr.Items.Add(cp);
                }
            }
        }

        //Displaying the cinematic productions that contain the provided partial name by the user
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            lbCinematicPr.Items.Clear();

            if (cpm.GetByPartialName(tbSearch.Text).Count > 0)
            {
                foreach (CinematicProduction p in cpm.GetByPartialName(tbSearch.Text))
                {
                    lbCinematicPr.Items.Add(p);
                }
            }
            else
            {
                lbCinematicPr.Items.Add("No results");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string image = cpm.ChooseImage();
            if (image != null)
            {
                pbImage.Image = Image.FromFile(image);
            }
            else
            {
                MessageBox.Show("The image you chose is not in the right format");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInForm form = new LogInForm();
            form.ShowDialog();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            string newPass = um.HashNewPass(tbPassword.Text, LogInForm.CurrentUser);

            if (um.EditInfo(new User(LogInForm.CurrentUser.Id, tbUsername.Text, newPass, tbPhoneNumber.Text)))
            {
                MessageBox.Show("You successfully updated your account information!");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbCinematicPr.SelectedIndex > -1)
            {
                CinematicProduction cp = (CinematicProduction)lbCinematicPr.SelectedItem;

                if (cpm.RemoveCP(cp))
                {
                    MessageBox.Show("You successfully removed the chosen cinematic production!");
                    GetProductions();
                }
                else
                {
                    MessageBox.Show("The cinematic production was NOT successfully removed!");
                }

            }
            else
            {
                MessageBox.Show("Please choose a movie from the list!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CinematicProduction cp;

            if (lbCinematicPr.SelectedIndex != -1)
            {
                cp = (CinematicProduction)lbCinematicPr.SelectedItem;
            }
            else
            {
                cp = cinPr;
            }

            

            if (this.cpm.CheckDate(tbReleaseDate.Text))
            {

                if (cp is Movie)
                {
                    if (cpm.UpdateCP(fc.CreateMovie(cp.Id, tbName.Text, rtbDescription.Text, tbReleaseDate.Text, Convert.ToInt32(tbRuntime.Text), Convert.ToDecimal(tbBudget.Text), tbStrPlt.Text, pbImage.Image)))
                    {
                        MessageBox.Show("You've successfully edited the movie details!");
                        GetProductions();
                    }
                }
                else
                {
                    if (cpm.UpdateCP(fc.CreateTVShow(cp.Id,tbName.Text, rtbDescription.Text, tbReleaseDate.Text, tbStrPlt.Text, Convert.ToInt32(tbSeasons.Text), Convert.ToInt32(tbEpisodes.Text), pbImage.Image)))
                    {
                        MessageBox.Show("You've successfully edited the tv show details!");
                        GetProductions();
                    }
                }
            }
            else
            {
                MessageBox.Show("You have entered an invalid date!");
            }
        }

        User selectedUser;

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (um.RemoveUser(selectedUser))
            {
                MessageBox.Show("You successfully removed the user");
                GetUsers();
            }

        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUser = (User)lbUsers.SelectedItem;
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
