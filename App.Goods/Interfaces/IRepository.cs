using System.Collections.Generic;

namespace App.Goods.Interfaces
{
    public interface IRepository<T> where T : IModel
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
    }
}