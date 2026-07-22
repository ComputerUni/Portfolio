using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
    public class _DefaultBannerViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultBannerViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var banner = _context.Banners.FirstOrDefault();
            return View(banner);
        }
    }
}
