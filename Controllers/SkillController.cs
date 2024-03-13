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


    }
}
