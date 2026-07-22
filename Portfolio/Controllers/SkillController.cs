using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using X.PagedList.Extensions;

namespace Portfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly AppDbContext _context;

        public SkillController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            var skills = _context.Skills.ToList();
            return View(skills.ToPagedList(page, 7));
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            return View(skill);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }
            _context.Skills.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
