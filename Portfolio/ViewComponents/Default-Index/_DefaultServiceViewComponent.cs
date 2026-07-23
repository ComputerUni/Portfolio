using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
    public class _DefaultServiceViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultServiceViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var services = _context.Services.ToList();
            return View(services);
        }
    }
}
