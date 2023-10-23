using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.ViewComponents
{
    public class RenderRangePriceViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderRangePrices");
        }
    }
}
