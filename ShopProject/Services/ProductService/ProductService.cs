namespace ShopProject.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly DataContext _db;

        public ProductService(DataContext db)
        {
            _db = db;
        }   

        public void Add(Product product)
        {
            product.Category = _db.Categories.FirstOrDefault(c => c.Id == product.CategoryId);

            _db.Products.Add(product);

            _db.SaveChanges();
            
            return;
        }

        public void Delete(Product product)
        {
            _db.Products.Remove(product);

            _db.SaveChanges();

            return;
        }

        public List<Product> List()
        {
            List<Product> products = _db.Products.ToList();

            return products;
        }

        public Product? Get(Guid id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);

            return product;
        }

        public void Update(Product product)
        {
            _db.Update(product);

            _db.SaveChanges();

            return;
        }
    }
}
