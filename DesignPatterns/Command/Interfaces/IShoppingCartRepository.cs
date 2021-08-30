using CommandPattern.Models;

namespace CommandPattern.Interfaces
{
    public interface IShoppingCartRepository
    {
        (Product Product, int Quantity) Get(string articleId);
        void Add(Product product);
        void RemoveAll(string articleId);
        void IncreaseQuantity(string articleId);
        void DecreaseQuantity(string articleId);
    }
}