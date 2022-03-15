using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace MoviesAndSeriesApplication
{
    public class CPDBManager
    {
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


        public int AddCP(string name, string description, string releaseDate, string strPlt, PictureBox pb)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "INSERT INTO cinematic_production (name, description, release_date, streaming_platform, image) VALUES (@Name, @Descr, @ReleaseDate, @StrPlt, @picture)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MemoryStream ms = new MemoryStream();

                pb.Image.Save(ms, pb.Image.RawFormat);

                byte[] img = ms.ToArray();

                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Descr", description);
                cmd.Parameters.AddWithValue("ReleaseDate", releaseDate);
                cmd.Parameters.AddWithValue("StrPlt", strPlt);
                cmd.Parameters.AddWithValue("picture", img);

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

        public int AddMovie(string name, string description, string releaseDate, int runtime, int budget, string strPlt, PictureBox pb)
        {
            if (AddCP(name, description, releaseDate, strPlt, pb) > 0)
            {
                MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

                try
                {
                    string sql = "INSERT INTO movie (id, runtime, budget) VALUES (@Id, @runtime, @budget);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Id", GetID(name));
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


        public int AddTvShow(string name, string description, string releaseDate, string strPlt, int seasons, int episodes, PictureBox pb)
        {
            if (AddCP(name, description, releaseDate, strPlt, pb) > 0)
            {
                MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

                try
                {
                    string sql = "INSERT INTO tvshow (id, seasons, episodes) VALUES (@Id, @Seasons, @Episodes);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Episodes", episodes);
                    cmd.Parameters.AddWithValue("Seasons", seasons);
                    cmd.Parameters.AddWithValue("Id", GetID(name));

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

        public int EditPCInfo(CinematicProduction cp, string name, string descr, string strPlt, string releaseDate)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "UPDATE cinematic_production SET name = @Name, description = @Descr, release_date = @ReleaseDate, streaming_platform = @StrPlt WHERE id = @Id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Descr", descr);
                cmd.Parameters.AddWithValue("ReleaseDate", releaseDate);
                cmd.Parameters.AddWithValue("StrPlt", strPlt);
                cmd.Parameters.AddWithValue("Id", cp.Id);

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

        public int EditMovieInfo(Movie mv, string name, string descr, string strPlt, string releaseDate, int runtime, decimal budget)
        {
            EditPCInfo(mv, name, descr, strPlt, releaseDate);

            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "UPDATE movie SET  runtime = @Runtime, budget = @Budget WHERE id = @Id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Runtime", runtime);
                cmd.Parameters.AddWithValue("Budget", budget);
                cmd.Parameters.AddWithValue("Id", mv.Id);

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

        public int EditTVShowInfo(TVShow ts, string name, string descr, string strPlt, string releaseDate, int Seasons, int Episodes)
        {
            EditPCInfo(ts, name, descr, strPlt, releaseDate);

            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "UPDATE tvshow SET Seasons = @Seasons, Episodes = @Episode WHERE Id = @Id)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Seasons", Seasons);
                cmd.Parameters.AddWithValue("Episodes", Episodes);
                cmd.Parameters.AddWithValue("Id", ts.Id);

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


        public int GetID(string name)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "SELECT id FROM cinematic_production WHERE name = @name";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("name", name);

                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                return result;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For regular users: Database problem\r\nFor software engineers: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        public Image GetImage(int id)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "SELECT Image FROM cinematic_production WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);

                conn.Open();

                byte[] img = (byte[])cmd.ExecuteScalar();

                MemoryStream ms = new MemoryStream(img);

                return Image.FromStream(ms);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"For regular users: Database problem\r\nFor software engineers: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        public void InsertImage(PictureBox pb)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            
        }

    }
}
