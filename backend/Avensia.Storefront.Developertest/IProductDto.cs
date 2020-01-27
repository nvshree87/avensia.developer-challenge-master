namespace Avensia.Storefront.Developertest
{
    public interface IProductDto
    {
        string Id { get; set; }
        string ProductName { get; set; }

        string CategoryId { get; set; }
        decimal Price { get; set; }
    }
}