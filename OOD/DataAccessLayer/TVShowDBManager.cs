using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace MoviesAndSeriesApplication
{
    public class TVShowDBManager
    {
        CPDBManager cpDB = new CPDBManager();

        public void GetSeries(List<CinematicProduction> productions)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "SELECT cp.id, name, description, release_date, streaming_platform, seasons, episodes FROM cinematic_production cp INNER JOIN tvshow ts ON cp.Id = ts.Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productions.Add(new TVShow(Convert.ToInt32(reader["id"]), reader["name"].ToString(), reader["description"].ToString(), reader["release_date"].ToString(), reader["streaming_platform"].ToString(), Convert.ToInt32(reader["seasons"]), Convert.ToInt32(reader["episodes"])));
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


        public int AddTvShow(string name, string description, string releaseDate, string strPlt, int seasons, int episodes, PictureBox pb)
        {
            if (cpDB.AddCP(name, description, releaseDate, strPlt, pb) > 0)
            {
                MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

                try
                {
                    string sql = "INSERT INTO tvshow (id, seasons, episodes) VALUES (@Id, @Seasons, @Episodes);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Episodes", episodes);
                    cmd.Parameters.AddWithValue("Seasons", seasons);
                    cmd.Parameters.AddWithValue("Id", cpDB.GetID(name));

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

        public int EditTVShowInfo(int id, string name, string descr, string strPlt, string releaseDate, int Seasons, int Episodes)
        {
            cpDB.EditPCInfo(id, name, descr, strPlt, releaseDate);

            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "UPDATE tvshow SET Seasons = @Seasons, Episodes = @Episodes WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Seasons", Seasons);
                cmd.Parameters.AddWithValue("Episodes", Episodes);
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
    }
}
