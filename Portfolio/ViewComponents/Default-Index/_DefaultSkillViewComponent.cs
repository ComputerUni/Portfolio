using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
    public class _DefaultSkillViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultSkillViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }
    }
}
