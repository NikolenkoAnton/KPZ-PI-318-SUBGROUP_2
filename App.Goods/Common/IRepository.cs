using System.Collections.Generic;

namespace App.Goods.Common
{
    public interface IRepository<T> where T : IModel
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}