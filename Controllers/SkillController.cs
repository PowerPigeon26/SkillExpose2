using Microsoft.AspNetCore.Mvc;
using SkillExpose2.Models;

namespace SkillExpose2.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepository repo;
        
        public SkillController(ISkillRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var skills = repo.GetAllSkills();

            return View(skills);
        }

        public IActionResult ViewSkill(int id)
        {
            var skill = repo.GetSkill(id);

            return View(skill);
        }

        public IActionResult UpdateSkill(int id)
        {
            Skill skill = repo.GetSkill(id);

            if (skill == null)
            {
                return View("SkillNotFound");
            }

            return View(skill);
        }

        public IActionResult UpdateSkillToDatabase(Skill skill)
        {
            repo.UpdateSkill(skill);

            return RedirectToAction("ViewSkill", new { id = skill.ID });
        }

        public IActionResult InsertSkill()
        {
            var skill = repo.AssignCategory();

            return View(skill);
        }

        public IActionResult InsertSkillToDatabase(Skill skill)
        {
            repo.InsertSkill(skill);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(Skill skill)
        {
            repo.DeleteSkill(skill);
            return RedirectToAction("Index");
        }
    }
}
