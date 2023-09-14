using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Services;

public interface ICategoryService
{
    IEnumerable<Category> GetAllCategories();

   
    Category GetCategoryById(int categoryId);

    
    void AddCategory(Category category);

    
    void UpdateCategory(Category category,int categoryId);

    
    void DeleteCategory(int categoryId);
}