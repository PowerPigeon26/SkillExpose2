using SkillExpose2.Models;

namespace SkillExpose2
{
    public interface ISkillRepository
    {
        public IEnumerable<Skill> GetAllSkills();
        public Skill GetSkill(int id);
        public void UpdateSkill(Skill skill);
        public void InsertSkill(Skill skill);
        public IEnumerable<Game> GetGames();
        public Skill AssignCategory();
        public void DeleteSkill(Skill skill);
    }
}
