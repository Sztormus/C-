namespace CommandPattern.Models
{
    public class Product
    {
        public string ArticleId { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Product(string articleId, string name, decimal price)
        {
            ArticleId = articleId;
            Name = name;
            Price = price;
        }
    }
}
