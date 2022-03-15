using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    class UserManager
    {

        UserDBM userDBM = new UserDBM();
        List<Person> people;

        public UserManager()
        {
            people = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            people.Add(person);
        }

        public bool CheckUser(string username, string password)
        {
            if (userDBM.CheckUsername(username) == 0)
            {
                MessageBox.Show("Wrong username");
                return false;
            }
            else if(userDBM.CheckPassword(password, username) == null)
            {
                MessageBox.Show("Wrong password");
                return false;
            }
            else
            {
                return true;
            }
        }

        public User GetUser(string username)
        {
            return userDBM.GetUser(username);
        }

        

        public void CreateNewAcc(string username, string password, string confirmPass, string email)
        {
            if (userDBM.CheckUsername(username) != 0)
            {
                MessageBox.Show("This username is alredy taken");
            }
            else
            {
                if (password != confirmPass)
                {
                    MessageBox.Show("Passwords aren't matching");
                }
                else
                {
                    userDBM.Register(username, email, password);
                    MessageBox.Show("Successful registration");
                }
            }
        }

        public int GetTypeOfAcc(string user)
        {
            return userDBM.GetTypeOfAcc(user);
        }

        
    }
}
