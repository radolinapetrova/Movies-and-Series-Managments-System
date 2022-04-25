using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using DataAccessLayer;
using Entities;


namespace MoviesAndSeriesApplication
{
    public class TVShowDBManager : ICRUD<CinematicProduction>
    {
        CPDBManager cpDB = new CPDBManager();

        MySqlConnection conn = DBConnection.Conn;

        public void Read(List<CinematicProduction> productions)
        {

            try
            {
                string sql = "SELECT cp.id, name, description, release_date, streaming_platform, seasons, episodes, image FROM cinematic_production cp INNER JOIN tvshow ts ON cp.Id = ts.Id LEFT JOIN cp_image ci ON cp.id = ci.cp_id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productions.Add(new TVShow(Convert.ToInt32(reader["id"]), reader["name"].ToString(), reader["description"].ToString(), reader["release_date"].ToString(), reader["streaming_platform"].ToString(), Convert.ToInt32(reader["seasons"]), Convert.ToInt32(reader["episodes"]), cpDB.GetImg(reader["image"]), this));
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



        public bool Add(CinematicProduction cp)
        {
            TVShow tv = (TVShow)cp;

            try
            {
                string sql = "INSERT INTO cinematic_production (name, description, release_date, streaming_platform) VALUES (@Name, @Descr, @ReleaseDate, @StrPlt);" +
                    "INSERT INTO tvshow (id, seasons, episodes) VALUES (LAST_INSERT_ID(), @Seasons, @Episodes);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("Name", tv.Name);
                cmd.Parameters.AddWithValue("Descr", tv.Description);
                cmd.Parameters.AddWithValue("ReleaseDate", tv.ReleaseDate);
                cmd.Parameters.AddWithValue("StrPlt", tv.StreamingPlatform);
                cmd.Parameters.AddWithValue("Episodes", tv.Episodes);
                cmd.Parameters.AddWithValue("Seasons", tv.Seasons);

                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (result == 2)
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




        public bool Update(CinematicProduction cp)
        {
            TVShow tv = (TVShow)cp;

            try
            {
                string sql = "UPDATE cinematic_production SET name = @Name, description = @Descr, release_date = @ReleaseDate, streaming_platform = @StrPlt WHERE id = @Id;" +
                    "UPDATE tvshow SET Seasons = @Seasons, Episodes = @Episodes WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("Name", tv.Name);
                cmd.Parameters.AddWithValue("Descr", tv.Description);
                cmd.Parameters.AddWithValue("ReleaseDate", tv.ReleaseDate);
                cmd.Parameters.AddWithValue("StrPlt", tv.StreamingPlatform);
                cmd.Parameters.AddWithValue("Seasons", tv.Seasons);
                cmd.Parameters.AddWithValue("Episodes", tv.Episodes);
                cmd.Parameters.AddWithValue("Id", tv.Id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                if (result == 2)
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

        public bool Delete(int id)
        {
            if (cpDB.Delete(id))
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
