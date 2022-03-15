using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MoviesAndSeriesApplication
{
    public class CPManager
    {

        CPDBManager dbManager = new CPDBManager();

        private List<CinematicProduction> productions;

        private IComparer<CinematicProduction> descNameComparer;
        private IComparer<CinematicProduction> descReleaseDateComparer;
        private IComparer<CinematicProduction> ascReleaseDateComparer;

        public CPManager()
        {
            productions = new List<CinematicProduction>();
            dbManager.GetMovies(productions);
            dbManager.GetSeries(productions);

        }

        public List<CinematicProduction> Productions { get { return productions; } }


        public CinematicProduction GetCP(string name)
        {
            return productions.Where(x => x.Name == name).First();
        }

        public void GetProductions(ListBox lb)
        {
            lb.Items.Clear();

            foreach (CinematicProduction p in productions)
            {
                lb.Items.Add(p.Name);
            }
        }

        public void GetMovies(ListBox lb)
        {
            lb.Items.Clear();

            foreach (CinematicProduction p in productions)
            {
                if (p is Movie)
                {
                    lb.Items.Add(p.Name);
                }
            }
        }


        public void GetTVshows(ListBox lb)
        {
            lb.Items.Clear();

            foreach (CinematicProduction p in productions)
            {
                if (p is TVShow)
                {
                    lb.Items.Add(p.Name);
                }
            }
        }

        //Method for case insensitive searching and cresating a list with the results
        private List<CinematicProduction> GetByName(TextBox tb)
        {
            return productions.Where(pr => pr.Name.ToLower().Contains(tb.Text.ToLower())).ToList();
        }

        //Displaying the results from the searching in the listbox
        public void GetByName(ListBox lb, TextBox tb)
        {
            lb.Items.Clear();

            if (GetByName(tb).Count > 0)
            {
                foreach (CinematicProduction p in GetByName(tb))
                {
                    lb.Items.Add(p.Name);
                }
            }
            else
            {
                lb.Items.Add("No results");
            }
        }

        public void SortNameDesc()
        {
            this.descNameComparer = new ProductionNameComparer();

            productions.Sort(this.descNameComparer);
        }

        public void SortDateDesc()
        {
            this.descReleaseDateComparer = new ProductionReleaseDateComparerDESC();

            productions.Sort(this.descReleaseDateComparer);

        }
        public void SortDateAsc()
        {
            this.ascReleaseDateComparer = new ProductionReleaseDateComparerASC();

            productions.Sort(this.ascReleaseDateComparer);

        }

        public void AddMovie(string name, string description, string releaseDate, int runtime, int budget, string strPlt, PictureBox pb)
        {
            if (dbManager.AddMovie(name, description, releaseDate, runtime, budget, strPlt, pb) > 0)
            {
                productions.Add(new Movie(dbManager.GetID(name), name, description, releaseDate, runtime, budget, strPlt));
                MessageBox.Show("You added the movie successfully");
            }
            else
            {
                MessageBox.Show("The movie was not added successfully");
            }

        }

        public void AddTVShow(string name, string description, string releaseDate, string strPlt, int seasons, int episodes, PictureBox pb)
        {
            if (dbManager.AddTvShow(name, description, releaseDate, strPlt, seasons, episodes, pb) > 0)
            {
                productions.Add(new TVShow(dbManager.GetID(name), name, description, releaseDate, strPlt, seasons, episodes));
                MessageBox.Show("You added the TV Show successfully");
            }
            else
            {
                MessageBox.Show("The TV Show was not added successfully");
            }

        }

        public void UpdateMovieInfo(Movie mv, string name, string descr, string strPlt, string releaseDate, int runtime, decimal budget)
        {
            if (dbManager.EditMovieInfo(mv, name, descr, strPlt, releaseDate, runtime, budget) > 0)
            {
                mv.Name = name;
                mv.Runtime = runtime;
                mv.ReleaseDate = releaseDate;
                mv.Description = descr;
                mv.Budget = budget;
                mv.StreamingPlatform = strPlt;

            }
            else
            {
                MessageBox.Show("The details of the movie were NOT edited successfully");
            }
        }

        public void UpdateTVShowInfo(TVShow ts, string name, string descr, string strPlt, string releaseDate, int Seasons, int Episodes)
        {
            if (dbManager.EditTVShowInfo(ts, name, descr, strPlt, releaseDate, Seasons, Episodes) > 0)
            {
                ts.ReleaseDate = releaseDate;
                ts.Description = descr;
                ts.Seasons = Seasons;
                ts.Episodes = Episodes;
                ts.StreamingPlatform = strPlt;
                ts.Name = name;
                MessageBox.Show("The details of the TV Show were edited successfully");
            }
            else
            {
                MessageBox.Show("The details of the TV Show were NOT edited successfully");
            }
        }

        public bool CheckDate(string date)
        {
            try
            {
                DateTime.ParseExact(date, "yyyy-MM-dd", null);
                return true;
            }
            catch
            {
                return false;

            }
        }

        public Image GetImage(int id)
        {
            return dbManager.GetImage(id);

        }


        public void ChooseImage(PictureBox pb)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image (*.jpg; *.png; *.jpeg)|*.jpg; *.png; *.jpeg";

            try
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    pb.Image = Image.FromFile(opf.FileName);
                }
            }
            catch (FormatException ex)
            {

                MessageBox.Show("The image you chose is not in the right fromat!");
            }
            
        }
    }
}
