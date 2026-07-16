using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class ProjectTechStacksController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectTechStacksController(AppDbContext context)
        {
            _context = context;
        }

        //Eager Loading(Tüm verileri en baştan yüklemek hem teknolojideki veriler hem teknolojideki veriler sql'deki inner join mantığına benziyor.)
        public IActionResult Index()
        {
            ViewBag.Values = _context.ProjectTechStacks.Include(x => x.Project).Include(x => x.TechStack).GroupBy(x => x.Project).Select(a => new
            {
                Project = a.Key,
                TechNames = a.Select(x => x.TechStack.Name).ToList()
            }).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var projects = _context.Projects.ToList();
            var techStacks = _context.TechStacks.ToList();
            ViewBag.projects = (from project in projects
                                select new SelectListItem
                                {
                                    Text = project.Name,
                                    Value = project.Id.ToString(),
                                }).ToList();

            ViewBag.techStacks = (from tech in techStacks
                                  select new SelectListItem
                                  {
                                      Text = tech.Name,
                                      Value = tech.Id.ToString()
                                  }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectTechStack projectTechStack)
        {
            _context.ProjectTechStacks.Add(projectTechStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
