// using Npgsql;
// using robot_controller_api.Models;

// namespace robot_controller_api.Persistence;

// public class RobotCommandRepository :
//     IRobotCommandDataAccess, IRepository
// {
//     private IRepository _repo => this;

//     public List<RobotCommandModel> GetRobotCommands()
//     {
//         return _repo.ExecuteReader<RobotCommandModel>(
//             "SELECT * FROM robotcommand");
//     }

//     public RobotCommandModel? GetRobotCommandById(int id)
//     {
//         var parameters = new NpgsqlParameter[]
//         {
//             new("id", id)
//         };

//         return _repo.ExecuteReader<RobotCommandModel>(
//             "SELECT * FROM robotcommand WHERE id=@id",
//             parameters).FirstOrDefault();
//     }

//     public void AddRobotCommand(RobotCommandModel command)
//     {
//         var parameters = new NpgsqlParameter[]
//         {
//             new("name", command.Name),
//             new("description", command.Description ?? (object)DBNull.Value),
//             new("ismovecommand", command.IsMoveCommand)
//         };

//         _repo.ExecuteReader<RobotCommandModel>(
//         @"INSERT INTO robotcommand
//         (""Name"",description,ismovecommand,createddate,modifieddate)
//         VALUES (@name,@description,@ismovecommand,NOW(),NOW())
//         RETURNING *", parameters);
//     }

//     public void UpdateRobotCommand(int id, RobotCommandModel command)
//     {
//         var parameters = new NpgsqlParameter[]
//         {
//             new("id", id),
//             new("name", command.Name),
//             new("description", command.Description ?? (object)DBNull.Value),
//             new("ismovecommand", command.IsMoveCommand)
//         };

//         _repo.ExecuteReader<RobotCommandModel>(
//         @"UPDATE robotcommand
//         SET ""Name""=@name,
//         description=@description,
//         ismovecommand=@ismovecommand,
//         modifieddate=NOW()
//         WHERE id=@id
//         RETURNING *", parameters);
//     }

//     public void DeleteRobotCommand(int id)
//     {
//         var parameters = new NpgsqlParameter[]
//         {
//             new("id", id)
//         };

//         _repo.ExecuteReader<RobotCommandModel>(
//         "DELETE FROM robotcommand WHERE id=@id RETURNING *",
//         parameters);
//     }
// }