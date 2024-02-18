using Microsoft.VisualBasic;
using OnlineShopWebApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class Repository<T> : IEnumerable<T>
        where T : IReposytoryItem
    {
        private List<T> Elements;
        public int Count { get { return Elements.Count; } }

        public Repository()
        {
            Elements = new List<T>();
        }

        public Repository(IEnumerable<T> elements)
        {
            Elements = elements.ToList();
        }

        public T TryGetElement(T element)
        {
            return Elements.FirstOrDefault(e => element.Equals(e));
        }

        public T TryGetElementById(int id)
        {
            return Elements.FirstOrDefault(e => e.Id == id);
        }

        public void Add(T element)
        {
            if (TryGetElement(element) is null)
                Elements.Add(element);
            //throw new ArgumentException("Товар с таким id уже есть в репозитории!");
        }

        public void Remove(T element)
        {
            Elements = Elements
                .Where(e => !e.Equals(element))
                .ToList();
        }

        public bool Contains(T element)
        {
            return Elements.Contains(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in Elements)
                yield return element;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //public T this[int index]
        //{
        //    get 
        //    {
        //        if (index >= 0 && index < Elements.Count)
        //            return Elements[index];
        //        throw new IndexOutOfRangeException();
        //    }
        //    //set { throw new NotImplementedException(); }
        //}
    }
}
