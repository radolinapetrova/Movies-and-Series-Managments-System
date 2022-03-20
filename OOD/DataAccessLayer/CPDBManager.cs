using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace MoviesAndSeriesApplication
{
    public class CPDBManager
    {

       
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
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Please choose an image!");
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        
        

        public int EditPCInfo(int id, string name, string descr, string strPlt, string releaseDate)
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

        public int RemoveCP(int id)
        {
            MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

            try
            {
                string sql = "DELETE FROM cinematic_production WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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
