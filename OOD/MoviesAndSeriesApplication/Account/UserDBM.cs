using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MoviesAndSeriesApplication
{
    public class UserDBM
    {
        MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");


        //Checking if a certain username exists
        public int CheckUsername(string username)
        {
            try
            {
                string sql = "SELECT COUNT(username) FROM person WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("username", username);
                
                conn.Open();

                Object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For users: Database problem!\r\nFor software engineers: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        //Checking if the password matches the username
        public string CheckPassword(string password, string username)
        {
            try
            {
                string sql = "SELECT password FROM person WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("username", username);

                conn.Open();

                Object result = cmd.ExecuteScalar();

                if (result.ToString() == password)
                {
                    return password;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For users: Database problem!\r\nFor software engineers: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        public User GetUser(string username)
        {
            try
            {
                string sql = "SELECT * FROM person WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("username", username);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                

                while (reader.Read())
                {
                    return new User(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["TypeOfAccount"]), reader["Username"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["Email"].ToString());
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For users: Database problem!\r\nFor software engineers: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        //Registering a new user 
        public void Register(string username,string email, string password)
        {
            try
            {
                string sql = "INSERT INTO person (Email, Username, Password, TypeOfAccount) VALUES (@Email, @Username, @Password, '1')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Username", username);
                cmd.Parameters.AddWithValue("Password", password);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                if (result != 0)
                {
                    MessageBox.Show("Successful registration!");
                }

              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For users: Database problem!\r\nFor software engineers: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }


        public int GetTypeOfAcc(string username)
        {
            try
            {
                string sql = "SELECT TypeOfAccount FROM person WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("username", username);

                conn.Open();

                Object result = cmd.ExecuteScalar();

                return (int)result;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For users: Database problem!\r\nFor software engineers: {ex.Message}");
            }
            finally
            {
                conn.Close ();
            }

            return -1;
        }

        

    }
}
