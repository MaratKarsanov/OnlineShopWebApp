namespace OnlineShopWebApp
{
    public interface IRepository<T>
    {
        T TryGetElementById(int id);
        void Add(T element);
    }
}
