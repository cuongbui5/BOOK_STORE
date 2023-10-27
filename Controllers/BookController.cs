using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BOOK_STORE_DEMO.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(IBookService bookService, ICategoryService categoryService,IWebHostEnvironment webHostEnvironment)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
            this.webHostEnvironment = webHostEnvironment;
        }
      
        public IActionResult ListBook()
        {
            IEnumerable<Book> books=bookService.GetAllBooks();
            return View(books);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Book book=bookService.GetBookById(id);
            ViewBag.Categories = new SelectList(categoryService.GetAllCategories(), "Id", "Name",book.CategoryId);
            return View(book); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name", "Price", "Description", "Author", "PublishDate", "Publisher,CategoryId")] Book newBook,IFormFile ?imgFile)
        {
            Book oldBook= bookService.GetBookById(id);
            if (oldBook == null)
            {
                return NotFound();
            }
            if(imgFile != null && imgFile.Length > 0 && imgFile.FileName!=oldBook.ImageCover)
            {
                string folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Upload\\images\\");
                string filePath = Path.Combine(folderPath, imgFile.FileName);
                string oldImgFile=Path.Combine(folderPath, oldBook.ImageCover);
                if (System.IO.File.Exists(oldImgFile)==true)
                {
                    System.IO.File.Delete(oldImgFile);
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imgFile.CopyToAsync(stream);
                }
                oldBook.ImageCover = imgFile.FileName;
            }
            else
            {
                newBook.ImageCover=oldBook.ImageCover;
            }
            oldBook.Name = newBook.Name;
            oldBook.Price= newBook.Price;
            oldBook.CategoryId = newBook.CategoryId;
            oldBook.Description= newBook.Description;
            oldBook.Author=newBook.Author;
            oldBook.PublishDate=newBook.PublishDate;
            oldBook.Publisher=newBook.Publisher;
            bookService.UpdateBook(oldBook);
            return RedirectToAction(nameof(ListBook));
        }

      
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories=new SelectList(categoryService.GetAllCategories(),"Id","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name","Price","Description","Author","PublishDate","Publisher,CategoryId")]Book book,IFormFile imgFile) 
        {
            if(ModelState.IsValid==false)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                ViewBag.Categories = new SelectList(categoryService.GetAllCategories(), "Id", "Name");
                return View();
            }
            if (imgFile != null && imgFile.Length>0)
            {
                string folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Upload\\images\\");
                string filePath=Path.Combine(folderPath,imgFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imgFile.CopyToAsync(stream);
                }
                book.ImageCover = imgFile.FileName;
                bookService.AddBook(book);
            }
            return RedirectToAction(nameof(ListBook));
        }

        public IActionResult Delete(int id)
        {
            Book book=bookService.GetBookById(id);
            string folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Upload\\images\\");
            string imgFilePath = Path.Combine(folderPath, book.ImageCover);
            if (System.IO.File.Exists(imgFilePath) == true)
            {
                System.IO.File.Delete(imgFilePath);
            }
            bookService.DeleteBook(id);
            return RedirectToAction(nameof(ListBook));
        }
    }
}
