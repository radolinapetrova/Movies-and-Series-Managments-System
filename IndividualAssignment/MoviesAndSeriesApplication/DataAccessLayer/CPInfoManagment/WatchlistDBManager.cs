using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesAndSeriesApplication;
using MySql.Data;
using MySql.Data.MySqlClient;
using Entities;


namespace DataAccessLayer
{
    public class WatchlistDBManager : IWatchlist
    {
        MySqlConnection conn = DBConnection.Conn;

        CPManager cpmanager = new CPManager(new MoviesDBManager(), new TVShowDBManager(), new CPDBManager());


        public void Read(User user)
        {
            try
            {
                string sql = "SELECT cp_id FROM watchlist WHERE user_id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", user.Id);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                List<CinematicProduction> cp = new List<CinematicProduction>();


                while (reader.Read())
                {
                    cp.Add(cpmanager.GetCP(Convert.ToInt32(reader["cp_id"])));
                }

                user.AssignWatchlist(new Watchlist(cp));

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

        public bool Add(User user, CinematicProduction cp)
        {
            try
            {
                string sql = "INSERT INTO watchlist (user_id, cp_id) VALUES (@user, @id);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("user", user.Id);
                cmd.Parameters.AddWithValue("id", cp.Id);
                

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

        public bool Delete(User user, CinematicProduction cp)
        {
            try
            {
                string sql = "DELETE FROM watchlist WHERE user_id = @user AND cp_id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("user", user.Id);
                cmd.Parameters.AddWithValue("id", cp.Id);


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
    
    }
}
