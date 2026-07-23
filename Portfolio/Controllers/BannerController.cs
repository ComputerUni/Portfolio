using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class BannerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BannerController(AppDbContext context, IWebHostEnvironment env)
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

            var path = Path.Combine(_env.WebRootPath, "uploads", "banner");
            Directory.CreateDirectory(path);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            using var stream = System.IO.File.Create(Path.Combine(path, fileName));
            await file.CopyToAsync(stream);

            return "/uploads/banner/" + fileName;
        }

        public IActionResult Index()
        {
            var banner = _context.Banners.FirstOrDefault();
            return View(banner);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(Banner banner, IFormFile? ImageFile)
        {
            ModelState.Remove("ImageUrl");
            var imageUrl = await SaveImageAsync(ImageFile);

            if (imageUrl == null)
            {
                ModelState.AddModelError("ImageUrl", "Görsel zorunludur.");
                return View(banner);
            }

            banner.ImageUrl = imageUrl;

            _context.Banners.Add(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateBanner(int id)
        {
            var banner = _context.Banners.Find(id);
            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(Banner banner, IFormFile? ImageFile)
        {
            var imageUrl = await SaveImageAsync(ImageFile);

            if (imageUrl != null)
            {
                banner.ImageUrl = imageUrl;
            }

            ModelState.Remove("ImageUrl");

            _context.Banners.Update(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBanner(int id)
        {
            var banner = _context.Banners.Find(id);
            _context.Banners.Remove(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
