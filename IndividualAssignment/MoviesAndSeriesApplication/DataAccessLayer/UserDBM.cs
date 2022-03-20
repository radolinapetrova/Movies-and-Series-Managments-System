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


                if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
                {
                    return 1;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For users: Database problem!\r\nFor software engineers: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("All fields are required");
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
            catch (NullReferenceException ex)
            {
                MessageBox.Show("All fields are required");
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
                    return new User(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["type_of_acc"]),  reader["username"].ToString(), reader["password"].ToString(), reader["email"].ToString(), reader["name"].ToString(), reader["phone_number"].ToString());
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For users: Database problem!\r\nFor software engineers: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("All fields are required");
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        //Registering a new user 
        public void Register(string username,string email, string password, string name, string number)
        {
            try
            {
                string sql = "INSERT INTO person (email, username, password, type_of_acc, name, phone_number) VALUES (@Email, @Username, @Password, '1', @name, @number)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Username", username);
                cmd.Parameters.AddWithValue("Password", password);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("number", number);

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
                string sql = "SELECT type_of_acc FROM person WHERE username = @username";
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

        public int EdiUserInfo(int id, string username, string password, string email, string number)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "UPDATE person SET username = @username, password = @password, email = @email, phone_number = @phone_number WHERE id = @Id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("phone_number", number);
                cmd.Parameters.AddWithValue("id", id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();
                MessageBox.Show("Data changed successfully!");

                return result;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For regular users: Database problem\r\nFor software engineers: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

    }
}
