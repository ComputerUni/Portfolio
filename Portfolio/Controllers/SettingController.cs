using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
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

            var path = Path.Combine(_env.WebRootPath, "uploads", "admin");
            Directory.CreateDirectory(path);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            using var stream = System.IO.File.Create(Path.Combine(path, fileName));
            await file.CopyToAsync(stream);

            return "/uploads/admin/" + fileName;
        }

        public IActionResult Index()
        {
            var admin = _context.Admins.FirstOrDefault();
            return View(admin);
        }

        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            var admin = _context.Admins.Find(id);
            return View(admin);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(Admin admin, IFormFile? ImageFile, string newPassword, string confirmPassword)
        {
            if(!string.IsNullOrEmpty(newPassword))
            {
                if(newPassword != confirmPassword)
                {
                    ModelState.AddModelError("","Şifreler birbirleriyle eşleşmiyor.");
                    return View(admin);
                }
                admin.Password = newPassword;
            }
           else
            {
                var existing = _context.Admins.Find(admin.Id);
                admin.Password = existing.Password;
                _context.Entry(existing).State = EntityState.Detached;
            }

            var imageUrl = await SaveImageAsync(ImageFile);

                if (imageUrl != null)
            {
                admin.ImageUrl = imageUrl;
            }

            ModelState.Remove("ImageUrl");
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
