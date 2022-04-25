using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Entities;
namespace MoviesAndSeriesApplication
{
    public class UserManager
    {

        ICRUD<User> manager;
        IAutoIncr autoIncr;

        List<User> users = new List<User>();

        public IList<User> Users { get { return users.AsReadOnly(); } }

        public UserManager(ICRUD<User> manager, IAutoIncr autoIncr)
        {
            this.manager = manager;
            this.autoIncr = autoIncr;

            this.users = new List<User>();
            manager.Read(users);
        }

        public bool CheckUsername(string username)
        {
            if (users.Any(u => u.Username == username))
            {
                return true;
            }
            return false;
        }

        public bool CheckPassword(string username, string password)
        {
            User user = GetUser(username);

            string hashPass = PasswordHasher.Hash(password + user.Salt);

            if (user.Password == hashPass)
            {
                return true;
            }
            return false;
        }

        public bool ConfirmPassword(string pass, string confirmPass)
        {
            if (pass == confirmPass)
            {
                return true;
            }
            return false;
        }

        public User GetUser(string username)
        {
            return users.Find(x => x.Username == username);
        }

        public bool Register(User newUser)
        {
            if (manager.Add(newUser))
            {
                users.Add(newUser);
                return true;
            }
            return false;
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

        public bool EditInfo(User user)
        {
            if (manager.Update(user))
            {
                int index = users.FindIndex(x => x.Id == user.Id);
                users[index] = user;
                return true;
            }
            return false;
        }


        public string[] GetPass(string password)
        {
            string salt = Guid.NewGuid().ToString();

            string[] pass = new string[] { salt, PasswordHasher.Hash(password + salt) };

            return pass;
        }

        public int GetId()
        {
            return autoIncr.GetId();
        }

        public bool RemoveUser(User user)
        {
            if (manager.Delete(user.Id))
            {
                users.Remove(user);
                return true;
            }
            return false;
        }

        public string HashNewPass(string password, User user)
        {
            return PasswordHasher.Hash(password + user.Salt);
        }
    }
}
