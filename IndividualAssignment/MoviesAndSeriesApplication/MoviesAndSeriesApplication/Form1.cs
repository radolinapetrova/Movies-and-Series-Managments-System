using Entities;

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
            um = new UserManager(new UserDBM(), new UserDBM());
        }

        UserManager um;

        static User currentUser;
        static string currentPassword;

        public static User CurrentUser { get { return currentUser; } }
        public static string CurrentPassword { get { return currentPassword; } }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (um.CheckUsername(tbUsername.Text))
            {
                if (um.CheckPassword(tbUsername.Text, tbPassword.Text))
                {
                    currentPassword = tbPassword.Text;
                    currentUser = um.GetUser(tbUsername.Text);


                    if (currentUser.TypeAcc == 1)
                    {
                        this.Hide();
                        MainMenu mm = new MainMenu();
                        mm.ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        ManagerForm mf = new ManagerForm();
                        mf.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }
            }
            else
            {
                MessageBox.Show("Wrong username");
            }
        }




        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbName.Text != String.Empty && tbNewPass.Text != String.Empty && tbNewUsername.Text != String.Empty && tbNumber.Text != String.Empty)
            {
                if (um.ConfirmPassword(tbNewPass.Text, tbConfirmPass.Text))
                {
                    if (um.ValidEmail(tbEmail.Text))
                    {
                        if (!um.CheckUsername(tbNewUsername.Text))
                        {

                            string[] pass = um.GetPass(tbNewPass.Text);

                            um.Register(new User(um.GetId(), 1, tbNewUsername.Text, pass[1], tbEmail.Text, tbName.Text, tbNumber.Text, pass[0]));
                            MessageBox.Show("Good job!!!");
                        }
                        else
                        {
                            MessageBox.Show("This username is already taken");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The email you have entered is invalid");
                    }
                }
                else
                {
                    MessageBox.Show("The passwords you entered are not matching");
                }
            }
            else
            {
                MessageBox.Show("All fields are required");
            }

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