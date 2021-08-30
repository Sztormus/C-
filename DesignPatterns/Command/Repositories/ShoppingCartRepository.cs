using System.Collections.Generic;
using CommandPattern.Interfaces;
using CommandPattern.Models;

namespace CommandPattern.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public readonly Dictionary<string, (Product Product, int Quantity)> LineItems = new();

        public (Product Product, int Quantity) Get(string articleId)
        {
            return LineItems.ContainsKey(articleId) 
                ? LineItems[articleId] 
                : (default, default);
        }

        public void Add(Product product)
        {
            if (LineItems.ContainsKey(product.ArticleId))
            {
                IncreaseQuantity(product.ArticleId);
            }
            else
            {
                LineItems[product.ArticleId] = (product, 1);
            }
        }

        public void DecreaseQuantity(string articleId)
        {
            if (LineItems.ContainsKey(articleId))
            {
                var (product, quantity) = LineItems[articleId];

                if (quantity == 1)
                    LineItems.Remove(articleId);
                else 
                    LineItems[articleId] = (Product: product, quantity - 1);
            }
            else
            {
                throw new KeyNotFoundException($"Product with article id {articleId} not in cart, please add first");
            }
        }

        public void IncreaseQuantity(string articleId)
        {
            if (LineItems.ContainsKey(articleId))
            {
                var (product, quantity) = LineItems[articleId];
                LineItems[articleId] = (Product: product, quantity + 1);
            }
            else
            {
                throw new KeyNotFoundException($"Product with article id {articleId} not in cart, please add first");
            }
        }

        public void RemoveAll(string articleId)
        {
            LineItems.Remove(articleId);
        }
    }
}
