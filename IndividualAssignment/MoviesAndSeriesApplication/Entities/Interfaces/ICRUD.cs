namespace Entities
{
    public interface ICRUD<T>
    {
        public bool Add(T obj);

        public bool Update(T obj);

        public void Read(List<T> objects);

        public bool Delete(int id);

    }
}
