using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.MessageCount = _context.UserMessages.Count();
            ViewBag.ReadMessageCount = _context.UserMessages.Count(x => x.IsRead);
            ViewBag.ProjectCount = _context.Projects.Count();
            ViewBag.ExperienceCount = _context.Experiences.Count();
            ViewBag.TestimonialCount = _context.Testimonials.Count();
            ViewBag.ServiceCount = _context.Services.Count();
            ViewBag.SkillsCount = _context.Skills.Count(x => x.IsActive);
            ViewBag.RecentProject = _context.Projects.OrderByDescending(x => x.Id).Take(2).ToList();
            ViewBag.RecentMessages = _context.UserMessages.OrderByDescending(x => x.Id).Take(3).ToList();
            return View();
        }
    }
}
