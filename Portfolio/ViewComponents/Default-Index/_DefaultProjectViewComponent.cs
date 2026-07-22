using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
    public class _DefaultProjectViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultProjectViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var projects = _context.Projects.Include(p => p.ProjectTechStacks).ThenInclude(pt => pt.TechStack).ToList();
            return View(projects);
        }
    }
}
