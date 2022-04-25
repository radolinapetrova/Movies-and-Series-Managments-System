using MySql.Data.MySqlClient;
using Entities;


namespace MoviesAndSeriesApplication
{
    public class UserDBM : ICRUD<User>, IAutoIncr
    {
        MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");


        public void Read(List<User> users)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");
            try
            {
                string sql = "SELECT * FROM user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User(Convert.ToInt32(Convert.ToInt32(reader["id"])), Convert.ToInt32(reader["type_of_acc"]), reader["username"].ToString(), reader["password"].ToString(), reader["email"].ToString(), reader["name"].ToString(), reader["phone_number"].ToString(), reader["salt"].ToString()));
                }
            }
            catch (MySqlException ex)
            {
                throw new ArgumentException("Database problem", ex);

            }
            finally
            {
                conn.Close();
            }
        }

        //Registering a new user 
        public bool Add(User user)
        {
            try
            {
                string sql = "INSERT INTO user (email, username, password, type_of_acc, name, phone_number, salt) VALUES (@Email, @Username, @Password, '1', @name, @number, @salt)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Email", user.Email);
                cmd.Parameters.AddWithValue("Username", user.Username);
                cmd.Parameters.AddWithValue("Password", user.Password);
                cmd.Parameters.AddWithValue("name", user.Name);
                cmd.Parameters.AddWithValue("number", user.PhoneNumber);
                cmd.Parameters.AddWithValue("salt", user.Salt);

                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (result == 1) 
                {
                    return true;
                }
                return false;

            }
            catch (MySqlException ex)
            {
                throw new ArgumentException("Database problem", ex);
            }
            finally
            {
                conn.Close();
            }
        }



        //Updating just specific info of the user
        public bool Update(User user)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "UPDATE user SET username = @username, password = @password, phone_number = @phone_number WHERE id = @Id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("username", user.Username);
                cmd.Parameters.AddWithValue("password", user.Password);
                cmd.Parameters.AddWithValue("phone_number", user.PhoneNumber);
                cmd.Parameters.AddWithValue("id", user.Id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();


                if (result == 1)
                {
                    return true;
                }
                return false;

            }
            catch (MySqlException ex)
            {
                throw new ArgumentException("Database problem", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public int GetId()
        {
            try
            {
                string sql = "SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbi478897' AND TABLE_NAME = 'person';";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                return result;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentException("Database problem", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "DELETE FROM user  WHERE id = @Id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                if (result == 1)
                {
                    return true;
                }
                return false;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentException("Database problem", ex);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
