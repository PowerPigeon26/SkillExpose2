using SkillExpose2.Models;

namespace SkillExpose2
{
    public interface ISkillRepository
    {
        public IEnumerable<Skill> GetAllSkills();
        public Skill GetSkill(int id);
        public void UpdateSkill(Skill skill);
    }
}
