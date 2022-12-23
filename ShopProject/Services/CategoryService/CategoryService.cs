namespace ShopProject.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _db;

        public CategoryService(DataContext db)
        {
            _db = db;
        }
        public void Add(Category category)
        {
            _db.Categories.Add(category);

            _db.SaveChanges();

            return;
        }

        public void Delete(Category category)
        {
            _db.Categories.Remove(category);

            _db.SaveChanges();

            return;
        }

        public Category? Get(Guid categoryId)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == categoryId);

            return category;
        }

        public List<Product>? GetProductsByCategory(Guid categoryId)
        {
            var category = Get(categoryId);

            if(category is null) {
                return null;
            }

            var result = category.Products.ToList();

            return result;
        }

        public List<Category> List()
        {
            return _db.Categories.ToList();
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);

            _db.SaveChanges();

            return;
        }
    }
}
