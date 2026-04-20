using robot_controller_api.Models;
using robot_controller_api.Persistence;

namespace robot_controller_api.DataAccess
{
    public class RobotCommandEF : IRobotCommandDataAccess
    {
        private readonly RobotContext _db;

        public RobotCommandEF(RobotContext db)
        {
            _db = db;
        }

        public List<RobotCommandModel> GetRobotCommands()
        {
            return _db.Robotcommands
                .Select(c => new RobotCommandModel(c.Id, c.Name, c.Ismovecommand, c.Createddate, c.Modifieddate, c.Description))
                .ToList();
        }

        public RobotCommandModel? GetRobotCommandById(int id)
        {
            var c = _db.Robotcommands.FirstOrDefault(x => x.Id == id);
            if (c == null) return null;
            return new RobotCommandModel(c.Id, c.Name, c.Ismovecommand, c.Createddate, c.Modifieddate, c.Description);
        }

        public void AddRobotCommand(RobotCommandModel command)
        {
            var newCmd = new Robotcommand
            {
                Name = command.Name,
                Description = command.Description,
                Ismovecommand = command.IsMoveCommand,
                Createddate = DateTime.Now,
                Modifieddate = DateTime.Now
            };
            _db.Robotcommands.Add(newCmd);
            _db.SaveChanges();
        }

        public void UpdateRobotCommand(int id, RobotCommandModel command)
        {
            var existing = _db.Robotcommands.Find(id);
            if (existing != null)
            {
                existing.Name = command.Name;
                existing.Description = command.Description;
                existing.Ismovecommand = command.IsMoveCommand;
                existing.Modifieddate = DateTime.Now;
                _db.SaveChanges();
            }
        }

        public void DeleteRobotCommand(int id)
        {
            var target = _db.Robotcommands.Find(id);
            if (target != null)
            {
                _db.Robotcommands.Remove(target);
                _db.SaveChanges();
            }
        }
    }
}