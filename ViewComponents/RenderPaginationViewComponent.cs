using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.ViewComponents
{
    public class RenderPaginationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderPaginate");
        }
    }
}
