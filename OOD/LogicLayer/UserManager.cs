using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MoviesAndSeriesApplication
{
    public class UserManager
    {

        UserDBM userDBM = new UserDBM();

        public bool CheckUsername(string username)
        {

            if (userDBM.CheckUsername(username) == 0)
            {
                MessageBox.Show("Wrong username");
                return false;
            }
            return true;
        }

        public bool CheckPassword(string username, string password)
        {
            if (userDBM.CheckPassword(password, username) == null)
            {
                MessageBox.Show("Wrong password");
                return false;
            }
            return true;
        }

        public User GetUser(string username)
        {
            return userDBM.GetUser(username);
        }

        
        public bool Register(string username, string email, string password, string name, string number)
        {
            userDBM.Register(username, email, password, name, number);
            return true;
        }

        public bool SamePassword(string password, string confirm)
        {
            if (password != confirm)
            {
                return false;
            }
            return true;
        }

        public bool ValidEmail(string email)
        {
            Regex validEmail = new Regex("(?<user>[^@]+)@(?<host>.+)");
            Match checkEmail = validEmail.Match(email);

            if (checkEmail.Success)
            {
                return true;
            }
            return false;
        }

        public bool TakenUsername(string username)
        {
            if (userDBM.CheckUsername(username) != 0)
            {
                return false;
            }
            return true;
        }

        public int GetTypeOfAcc(string user)
        {
            return userDBM.GetTypeOfAcc(user);
        }

        public void EditInfo(int id, string username, string password, string email, string number)
        {
            userDBM.EdiUserInfo(id, username, password, email, number);
        }
        
    }
}
