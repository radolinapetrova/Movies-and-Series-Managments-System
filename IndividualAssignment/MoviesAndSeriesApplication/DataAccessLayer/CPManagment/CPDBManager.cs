using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using DataAccessLayer;
using Entities;
using MoviesAndSeriesApplication;

namespace MoviesAndSeriesApplication
{
    public class CPDBManager : ISort,  IAutoIncr
    {
        MySqlConnection conn = DBConnection.Conn;



        //        if (image != null)
        //        {
        //            MemoryStream ms = new MemoryStream();

        //            image.Save(ms, image.RawFormat);

        //            byte[] img = ms.ToArray();
        //            cmd.Parameters.AddWithValue("picture", img);
        //        }






        //Checks if the given cinematic production has an image and if nor returns null
        public Image GetImg(Object obj)
        {
            if (!DBNull.Value.Equals(obj))
            {
                byte[] img = (byte[])obj;
                MemoryStream ms = new MemoryStream(img);
                return Image.FromStream(ms);
            }
            else
            {
                return null;
            }
        }


        //sql statement that retrieves the next auto increment id before the data is inserted from a given table
        public int GetId()
        {
            try
            {
                string sql = "SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbi478897' AND TABLE_NAME = 'cinematic_production';";

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
            try
            {
                string sql = "DELETE FROM cinematic_production WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Id", id);

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

       
       

        public List<int> Sort(string item, string order)
        {
            try
            {
                string sql = $"SELECT id FROM cinematic_production ORDER BY {item} {order}";
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                List<int> list = new List<int>();

                while (reader.Read())
                {
                    list.Add(Convert.ToInt32(reader["id"]));
                }
                return list;
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







        //public List<string> GetLimitedCP(int limit, int offset)
        //{
        //    try
        //    {
        //        string sql = $"SELECT name FROM cinematic_production LIMIT {limit} OFFSET {offset};";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        conn.Open();
        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        List<string> titles = new List<string>();

        //        while (reader.Read())
        //        {
        //            titles.Add(reader["name"].ToString());
        //        }
        //        return titles;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        throw new ArgumentException("Database problem", ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
            
        //}
    }
}
