using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repository;

public class CategoryRepository:ICategoryRepository
{
    private readonly BookStoreDBContext context;
    public CategoryRepository(BookStoreDBContext context)
    {
        this.context = context;
    }
    public IEnumerable<Category> GetAllCategories()
    {
        return context.Categories.ToList();
    }

    public Category GetCategoryById(int categoryId)
    {
        return context.Categories.Find(categoryId);
    }

    public void AddCategory(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        context.Categories.Update(category);
        context.SaveChanges();
    }

    public void DeleteCategory(int categoryId)
    {
        var category = context.Categories.Find(categoryId);
        if (category != null)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}