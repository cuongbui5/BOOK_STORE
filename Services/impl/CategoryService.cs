using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Repository;

namespace BOOK_STORE_DEMO.Services;

public class CategoryService:ICategoryService
{
    private readonly ICategoryRepository categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }
    public IEnumerable<Category> GetAllCategories()
    {
        return categoryRepository.GetAllCategories();
    }

    public Category GetCategoryById(int categoryId)
    {
        return categoryRepository.GetCategoryById(categoryId);
    }

    public void AddCategory(Category category)
    {
        categoryRepository.AddCategory(category);
    }

    public void UpdateCategory(Category category,int categoryId)
    {
        Category categoryUp = categoryRepository.GetCategoryById(categoryId);
        if (categoryUp != null)
        {
            categoryUp.Name = category.Name;
            categoryRepository.UpdateCategory(categoryUp);
        }
    }

    public void DeleteCategory(int categoryId)
    {
        categoryRepository.DeleteCategory(categoryId);
    }
}