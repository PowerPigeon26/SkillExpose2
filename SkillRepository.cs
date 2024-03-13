using Dapper;
using SkillExpose2.Models;
using System.Data;

namespace SkillExpose2
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IDbConnection _conn;

        public SkillRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return _conn.Query<Skill>("SELECT * FROM skills");
        }

        public Skill GetSkill(int id)
        {
            return _conn.QuerySingle<Skill>("SELECT * FROM skills WHERE ID = @id",
                new { id = id});
        }

        public void UpdateSkill(Skill skill)
        {
            _conn.Execute("UPDATE skills SET Name = @name, GameID = @gameid, Game = @game, Type = @type, " +
                "InGameDescription = @inGameDes, AdditionalDescription = @addDes, Notes = @notes, YTVideoName = @ytvidname, YTCode = @ytcode," +
                "TSStart = @start, TSEnd = @end WHERE ID = @id", 
                new { name = skill.Name, gameid = skill.GameID, game = skill.Game, type = skill.Type, inGameDes = skill.InGameDescription,
                addDes = skill.AdditionalDescription, notes = skill.Notes, ytvidName = skill.YTVideoName, ytcode = skill.YTCode,
                start = skill.TSStart, end = skill.TSEnd, id = skill.ID});
        }

        public void InsertSkill(Skill skill)
        {
            _conn.Execute("INSERT INTO skills (NAME, GAMEID, GAME, TYPE, INGAMEDESCRIPTION, ADDITIONALDESCRIPTION, NOTES, YTVIDEONAME," +
                "YTCODE, TSSTART, TSEND) VALUES (@name, @gameid, @game, @type, @ingamedescription, @additionaldescription, @notes," +
                "@ytvideoname, @ytcode, @tsstart, @tsend);",
                new
                {
                    name = skill.Name,
                    gameid = skill.GameID,
                    game = skill.Game,
                    type = skill.Type,
                    ingamedescription = skill.InGameDescription,
                    additionaldescription = skill.AdditionalDescription,
                    notes = skill.Notes,
                    ytvideoname = skill.YTVideoName,
                    ytcode = skill.YTCode,
                    tsstart = skill.TSStart,
                    tsend = skill.TSEnd
                });
        }

        public IEnumerable<Game> GetGames()
        {
            return _conn.Query<Game>("SELECT * FROM games;");
        }

        public Skill AssignCategory()
        {
            var gameList = GetGames();
            var skill = new Skill();
            skill.Games = gameList;

            return skill;
        }

        public void DeleteSkill(Skill skill)
        {
            _conn.Execute("DELETE FROM skills WHERE ID = @id;", new { id = skill.ID });
        }
    }
}
