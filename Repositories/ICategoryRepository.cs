using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repository;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories();

   
    Category GetCategoryById(int categoryId);

    
    void AddCategory(Category category);

    
    void UpdateCategory(Category category);
    
    void DeleteCategory(int categoryId);
    
}