namespace CommandPattern.Interfaces
{
    public interface IProductRepository
    {
        int GetStockFor(string articleId);
        void DecreaseStockBy(string articleId, int amount);
        void IncreaseStockBy(string articleId, int amount);
    }
}