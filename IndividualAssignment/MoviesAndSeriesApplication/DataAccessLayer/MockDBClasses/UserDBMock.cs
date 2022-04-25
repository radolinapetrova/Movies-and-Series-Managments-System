using MoviesAndSeriesApplication;
using Entities;


namespace DataAccessLayer
{
    public class UserDBMock : ICRUD<User>, IAutoIncr
    {
        public void Read(List<User> users)
        {
            users.Add(new User(1, 1, "radka", "efff3f05eea17dd2180d6da4e1aaf34ec00a38a4b1e700c56bd60c1d975988ca", "selska_moma@gmail.com", "Radiii", "1", "16c541b3-6f06-4a6a-b4c2-aaceaf92500d"));
        }

        public bool Add(User user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }

        public bool Update(User user)
        {
            return true;
        }

        public int GetId()
        {
            return 0;
        }
    }
}
