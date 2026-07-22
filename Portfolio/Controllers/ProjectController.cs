using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using X.PagedList.Extensions;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProjectController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        private async Task<string?> SaveImageAsync(IFormFile? file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var path = Path.Combine(_env.WebRootPath, "uploads", "projects");
            Directory.CreateDirectory(path);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            using var stream = System.IO.File.Create(Path.Combine(path, fileName));
            await file.CopyToAsync(stream);

            return "/uploads/projects/" + fileName;
        }

        public IActionResult Index(int page = 1)
        {
            var projects = _context.Projects.ToList();
            return View(projects.ToPagedList(page, 7));
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project, IFormFile? ImageFile)
        {
            ModelState.Remove("ImageUrl");

            var imageUrl = await SaveImageAsync(ImageFile);

            if (imageUrl == null)
            {
                ModelState.AddModelError("ImageUrl", "Görsel zorunludur.");
                return View(project);
            }

            project.ImageUrl = imageUrl;

            if (!ModelState.IsValid)
            {
                return View(project);
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var project = _context.Projects.Find(id);
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(Project project, IFormFile? ImageFile)
        {
            var imageUrl = await SaveImageAsync(ImageFile);

            if (imageUrl != null)
            {
                project.ImageUrl = imageUrl;
            }

            ModelState.Remove("ImageUrl");

            if (!ModelState.IsValid)
            {
                return View(project);
            }

            _context.Projects.Update(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
