using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using MoviesAndSeriesApplication;


namespace MoviesAndSeriesApplication
{
    public class MoviesDBManager
    {
        CPDBManager cpDB = new CPDBManager();

        public void GetMovies(List<CinematicProduction> productions)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");
            try
            {
                string sql = "SELECT cp.id, name, description, release_date, streaming_platform, budget, runtime FROM cinematic_production cp INNER JOIN movie m ON cp.Id = m.Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productions.Add(new Movie(Convert.ToInt32(reader["id"]), reader["name"].ToString(), reader["description"].ToString(), reader["release_date"].ToString(), Convert.ToInt32(reader["runtime"]), Convert.ToDecimal(reader["budget"]), reader["streaming_platform"].ToString()));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For regular users: Database problem\r\nFor software engineers: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }


        public int AddMovie(string name, string description, string releaseDate, int runtime, int budget, string strPlt, PictureBox pb)
        {
            if (cpDB.AddCP(name, description, releaseDate, strPlt, pb) > 0)
            {
                MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

                try
                {
                    string sql = "INSERT INTO movie (id, runtime, budget) VALUES (@Id, @runtime, @budget);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Id", cpDB.GetID(name));
                    cmd.Parameters.AddWithValue("runtime", runtime);
                    cmd.Parameters.AddWithValue("budget", budget);

                    conn.Open();

                    int result = cmd.ExecuteNonQuery();

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
            }
            return 0;
        }


        public int EditMovieInfo(int id, string name, string descr, string strPlt, string releaseDate, int runtime, decimal budget)
        {
            cpDB.EditPCInfo(id, name, descr, strPlt, releaseDate);

            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "UPDATE movie SET  runtime = @Runtime, budget = @Budget WHERE id = @Id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Runtime", runtime);
                cmd.Parameters.AddWithValue("Budget", budget);
                cmd.Parameters.AddWithValue("Id", id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

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


        public bool DeleteMovie(int id)
        {
            if (cpDB.RemoveCP(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
