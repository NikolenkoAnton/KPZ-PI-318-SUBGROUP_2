namespace App.Goods.Common
{
    public interface IAddOnRepository<T> : IRepository<T> where T : IModel
    {
        void Add(T item);
    }
}
