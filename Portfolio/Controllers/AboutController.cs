using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(AppDbContext context, IWebHostEnvironment env)
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

            var path = Path.Combine(_env.WebRootPath, "uploads", "abouts");
            Directory.CreateDirectory(path);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            using var stream = System.IO.File.Create(Path.Combine(path, fileName));
            await file.CopyToAsync(stream);

            return "/uploads/abouts/" + fileName;
        }

        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();
            return View(about);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(About about, IFormFile? ImageFile)
        {
            ModelState.Remove("ImageUrl");

            var imageUrl = await SaveImageAsync(ImageFile);

            if(imageUrl == null)
            {
                ModelState.AddModelError("ImageUrl", "Görsel zorunludur.");
                return View(about);
            }

            about.ImageUrl = imageUrl;

            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(About about, IFormFile? ImageFile)
        {
            ModelState.Remove("ImageUrl");
            var imageUrl = await SaveImageAsync(ImageFile);

            if (imageUrl != null)
            {
                about.ImageUrl = imageUrl;
            }

            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
