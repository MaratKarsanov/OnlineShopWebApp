using System.Collections;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IRepository<T> : IEnumerable<T>
    {
        T TryGetElementById(int id);
        void Add(T element);
    }
}
