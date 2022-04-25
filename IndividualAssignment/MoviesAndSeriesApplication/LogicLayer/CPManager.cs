using Entities;

namespace MoviesAndSeriesApplication
{
    public class CPManager
    {

        public CPManager(ICRUD<CinematicProduction> movieManager, ICRUD<CinematicProduction> tvManager, ISort sortManager)
        {
            productions = new List<CinematicProduction>();

            movieManager.Read(productions);
            tvManager.Read(productions);

            this.cpSortManager = sortManager;
        }


        ISort cpSortManager;


        private List<CinematicProduction> productions;

        public IList<CinematicProduction> Productions { get { return productions.AsReadOnly(); } }




        //Method for retrieving a Cinematic production by its id
        public CinematicProduction GetCP(int id)
        {
            return productions.Find(x => x.Id == id);
        }


        //Method for case insensitive searching and cresating a list with the results
        public List<CinematicProduction> GetByPartialName(string text)
        {
            return productions.Where(pr => pr.Name.ToLower().Contains(text.ToLower())).ToList();
        }

        //Checking if the date that the user entered is valid
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


        public bool RemoveCP(CinematicProduction cp)
        {
            if (cp.Manager.Delete(cp.Id))
            {
                productions.Remove(GetCP(cp.Id));
                return true;
            }
            return false;
        }


        public bool AddCP(CinematicProduction cp)
        {
            if (cp.Manager.Add(cp))
            {
                productions.Add(cp);
                return true;
            }
            return false;
        }

       

        public bool UpdateCP(CinematicProduction newCP)
        {
            if (newCP.Manager.Update(newCP))
            {
                int index = productions.FindIndex(x => x.Id == newCP.Id);
                productions[index] = newCP;
                return true;
            }

            return false;
        }

        
        //Retrieves the sorted list of ids according to the user's preferences and returns a list of sorted objects
        public List<CinematicProduction> Sort(string item, string order)
        {
            List<int> sortedId = cpSortManager.Sort(item, order);

            List<CinematicProduction> sortedCP = new List<CinematicProduction>();

            for (int i = 0; i < sortedId.Count; i++)
            {
                sortedCP.Add(GetCP(sortedId[i]));
            }

            return sortedCP;
        }



        public string ChooseImage()
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image (*.jpg; *.png; *.jpeg)|*.jpg; *.png; *.jpeg";

            try
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    return opf.FileName;
                }
            }
            catch (FormatException ex)
            {

            }
            return null;

        }



        //WAD
        public string ConvertImage(int id)
        {
            Image img = GetCP(id).Image;

            if (img == null)
            {
                return null;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                img.Save(ms, img.RawFormat);

                string base64 = Convert.ToBase64String(ms.ToArray());

                return string.Format("data:img/jpg;base64,{0}", base64);
            }


        }

        public List<string> GetCP(int limit, int offset)
        {
            //return .GetLimitedCP(limit, offset);
            return null;
        }

    }
}
