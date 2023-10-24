using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.VewComponents;

public class RenderCategoryViewComponent:ViewComponent
{
    private IEnumerable<Category> categories = new List<Category>();
    private readonly ICategoryService categoryService;
   

    public RenderCategoryViewComponent(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
        categories = this.categoryService.GetAllCategories();
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("RenderCategory", categories);
    }
   
}