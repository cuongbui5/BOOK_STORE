using System.Collections;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.Controllers;

public class CategoryController : Controller
{

    private readonly ICategoryService categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    // GET
    public IActionResult Index()
    {
        IEnumerable<Category> categories = categoryService.GetAllCategories();
        if (!categories.Any())
        {
            ViewBag.Categories = null;
        }
        else
        {
            ViewBag.Categories = categories;
        }

        

        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        categoryService.AddCategory(category);   
        return RedirectToAction("Index","Category");
    }
    
    public IActionResult Update(int id)
    {
        Category category = categoryService.GetCategoryById(id);
        ViewBag.Category = category;
        return View();
    }
    
    [HttpPost]
    public IActionResult Update(Category category,int id)
    {
        categoryService.UpdateCategory(category,id);  
        return RedirectToAction("Index","Category");
    }
    
    public IActionResult Delete(int id)
    {
        categoryService.DeleteCategory(id);  
        return RedirectToAction("Index","Category");
    }
}