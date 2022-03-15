namespace MoviesAndSeriesApplication
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            tbPassword.UseSystemPasswordChar = true;
            tbNewPass.UseSystemPasswordChar = true;
            tbConfirmPass.UseSystemPasswordChar = true;
        }

        UserManager um = new UserManager();

        static string currentUser;

        public static string CurrentUser { get { return currentUser; } }

        private void btnLogIn_Click(object sender, EventArgs e)
        {

            if (um.CheckUser(tbUsername.Text, tbPassword.Text))
            {
                currentUser = tbUsername.Text;

                if (um.GetTypeOfAcc(tbUsername.Text) == 1)
                {
                    this.Hide();
                    MainMenu mm = new MainMenu();
                    mm.ShowDialog();
                }
                else
                {
                    ManagerForm mf = new ManagerForm();
                    mf.ShowDialog();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            um.CreateNewAcc(tbNewUsername.Text, tbNewPass.Text, tbConfirmPass.Text, tbEmail.Text);
        }

        private void tbConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (tbNewPass.Text != tbConfirmPass.Text)
            {
                tbConfirmPass.BackColor = Color.FromArgb(255, 192, 192);
                tbNewPass.BackColor = Color.FromArgb(255, 192, 192);
            }
            else
            {
                tbNewPass.BackColor = Color.White;
                tbConfirmPass.BackColor = Color.White;
            }
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

        int check = 0;

        private void cbNewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (check == 0)
            {
                tbNewPass.UseSystemPasswordChar = false;
                tbConfirmPass.UseSystemPasswordChar = false;
                tbNewPass.PasswordChar = '\0';
                tbConfirmPass.PasswordChar = '\0';
                check++;
            }
            else
            {
                tbNewPass.UseSystemPasswordChar = true;
                tbConfirmPass.UseSystemPasswordChar = true;
                check--;
            }
        }
    }
}