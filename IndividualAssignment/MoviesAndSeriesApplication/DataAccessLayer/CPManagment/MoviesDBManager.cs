using MySql.Data.MySqlClient;
using DataAccessLayer;
using Entities;


namespace MoviesAndSeriesApplication
{
    public class MoviesDBManager : ICRUD<CinematicProduction>
    {
        CPDBManager cpDB = new CPDBManager();

        MySqlConnection conn = DBConnection.Conn;

        public void Read(List<CinematicProduction> productions)
        {
            try
            {
                string sql = "SELECT cp.id, name, description, release_date, streaming_platform, budget, runtime, image FROM cinematic_production cp INNER JOIN movie m ON cp.Id = m.Id LEFT JOIN cp_image ci ON cp.id = ci.cp_id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productions.Add(new Movie(Convert.ToInt32(reader["id"]), reader["name"].ToString(), reader["description"].ToString(), reader["release_date"].ToString(), Convert.ToInt32(reader["runtime"]), Convert.ToDecimal(reader["budget"]), reader["streaming_platform"].ToString(), cpDB.GetImg(reader["image"]), this));
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
            Movie mv = (Movie)cp;

            try
            {
                string sql = "INSERT INTO cinematic_production (name, description, release_date, streaming_platform) VALUES (@Name, @Descr, @ReleaseDate, @StrPlt);" +
                    "INSERT INTO movie (id, runtime, budget) VALUES (LAST_INSERT_ID(), @runtime, @budget);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Name", mv.Name);
                cmd.Parameters.AddWithValue("Descr", mv.Description);
                cmd.Parameters.AddWithValue("ReleaseDate", mv.ReleaseDate);
                cmd.Parameters.AddWithValue("StrPlt", mv.StreamingPlatform);
                cmd.Parameters.AddWithValue("runtime", mv.Runtime);
                cmd.Parameters.AddWithValue("budget", mv.Budget);

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



        public bool Update(CinematicProduction newCP)
        {
            Movie mv = (Movie)newCP;

            try
            {
                string sql = "UPDATE cinematic_production SET name = @Name, description = @Descr, release_date = @ReleaseDate, streaming_platform = @StrPlt WHERE id = @Id;" +
                    "UPDATE movie SET  runtime = @Runtime, budget = @Budget WHERE id = @Id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("Name", mv.Name);
                cmd.Parameters.AddWithValue("Descr", mv.Description);
                cmd.Parameters.AddWithValue("ReleaseDate", mv.ReleaseDate);
                cmd.Parameters.AddWithValue("StrPlt", mv.StreamingPlatform);
                cmd.Parameters.AddWithValue("Runtime", mv.Runtime);
                cmd.Parameters.AddWithValue("Budget", mv.Budget);
                cmd.Parameters.AddWithValue("Id", mv.Id);

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
