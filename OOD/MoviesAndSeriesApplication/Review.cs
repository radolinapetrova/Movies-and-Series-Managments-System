using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public class Review
    {
        private int id;
        private int movieId;
        private string comment;
        private DateTime date;
        private int likes;
        private int dislikes;
        private int userId;

        public Review(int movieId, string comment, DateTime date, int likes, int dislikes, int userId)
        {
            this.movieId = movieId;
            this.comment = comment; 
            this.date = date;
            this.likes = likes;
            this.dislikes = dislikes;
            this.userId = userId;
        }

        public string GetInfo()
        {
            return $"{this.userId}: {this.comment}\r\n{this.date} {this.likes} {this.dislikes}";
        }
    }
}
