namespace ShopProject.Services.ProductService
{
    public interface IProductService
    {
        List<Product> List();
        Product? Get(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
