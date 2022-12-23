namespace ShopProject.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Product>? GetProductsByCategory(Guid categoryId);
        List<Category> List();
        Category? Get(Guid categoryId);
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
    }
}
