using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using X.PagedList.Extensions;

namespace Portfolio.Controllers
{
    public class UserMessageController : Controller
    {
        private readonly AppDbContext _context;

        public UserMessageController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, bool? isRead = null)
        {
            var messages = _context.UserMessages.AsQueryable();

            if(isRead.HasValue)
            {
                messages = messages.Where(m => m.IsRead == isRead.Value);
            }
            var list = _context.UserMessages.ToList();
            ViewBag.IsRead = isRead;
            ViewBag.AllRead = !_context.UserMessages.Any(x => !x.IsRead);
            ViewBag.AllUnread = !_context.UserMessages.Any(x => x.IsRead);
            return View(messages.ToPagedList(page, 7));
        }

        public IActionResult DetailMessage(int id)
        {
            var message = _context.UserMessages.Find(id);
            message.IsRead = true;
            _context.SaveChanges();
            return View(message);
        }

        public IActionResult DeleteMessage(int id)
        {
            var message = _context.UserMessages.Find(id);
            _context.UserMessages.Remove(message);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
