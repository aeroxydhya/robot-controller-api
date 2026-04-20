// using Npgsql;
// using robot_controller_api.Models;

// namespace robot_controller_api.Persistence;

// public class RobotCommandADO : IRobotCommandDataAccess
// {
//     private const string CONNECTION_STRING =
//     "Host=localhost;Username=postgres;Password=Pass123;Database=sit331";

//     public List<RobotCommandModel> GetRobotCommands()
//     {
//         var commands = new List<RobotCommandModel>();

//         using var conn = new NpgsqlConnection(CONNECTION_STRING);
//         conn.Open();

//         using var cmd = new NpgsqlCommand("SELECT * FROM robotcommand", conn);
//         using var dr = cmd.ExecuteReader();

//         while (dr.Read())
//         {
//             commands.Add(new RobotCommandModel(
//                 (int)dr["id"],
//                 (string)dr["Name"],
//                 (bool)dr["ismovecommand"],
//                 (DateTime)dr["createddate"],
//                 (DateTime)dr["modifieddate"],
//                 dr["description"] as string
//             ));
//         }

//         return commands;
//     }

//     public RobotCommandModel? GetRobotCommandById(int id)
//     {
//         using var conn = new NpgsqlConnection(CONNECTION_STRING);
//         conn.Open();

//         using var cmd =
//         new NpgsqlCommand("SELECT * FROM robotcommand WHERE id=@id", conn);

//         cmd.Parameters.AddWithValue("id", id);

//         using var dr = cmd.ExecuteReader();

//         if (dr.Read())
//         {
//             return new RobotCommandModel(
//                 (int)dr["id"],
//                 (string)dr["Name"],
//                 (bool)dr["ismovecommand"],
//                 (DateTime)dr["createddate"],
//                 (DateTime)dr["modifieddate"],
//                 dr["description"] as string
//             );
//         }

//         return null;
//     }

//     public void AddRobotCommand(RobotCommandModel command)
//     {
//         using var conn = new NpgsqlConnection(CONNECTION_STRING);
//         conn.Open();

//         var sql = @"INSERT INTO robotcommand
//         (""Name"", description, ismovecommand, createddate, modifieddate)
//         VALUES (@name,@desc,@move,NOW(),NOW())";

//         using var cmd = new NpgsqlCommand(sql, conn);

//         cmd.Parameters.AddWithValue("name", command.Name);
//         cmd.Parameters.AddWithValue("desc", (object?)command.Description ?? DBNull.Value);
//         cmd.Parameters.AddWithValue("move", command.IsMoveCommand);

//         cmd.ExecuteNonQuery();
//     }

//     public void UpdateRobotCommand(int id, RobotCommandModel command)
//     {
//         using var conn = new NpgsqlConnection(CONNECTION_STRING);
//         conn.Open();

//         var sql = @"UPDATE robotcommand
//         SET ""Name""=@name,
//         description=@desc,
//         ismovecommand=@move,
//         modifieddate=NOW()
//         WHERE id=@id";

//         using var cmd = new NpgsqlCommand(sql, conn);

//         cmd.Parameters.AddWithValue("name", command.Name);
//         cmd.Parameters.AddWithValue("desc", (object?)command.Description ?? DBNull.Value);
//         cmd.Parameters.AddWithValue("move", command.IsMoveCommand);
//         cmd.Parameters.AddWithValue("id", id);

//         cmd.ExecuteNonQuery();
//     }

//     public void DeleteRobotCommand(int id)
//     {
//         using var conn = new NpgsqlConnection(CONNECTION_STRING);
//         conn.Open();

//         using var cmd =
//         new NpgsqlCommand("DELETE FROM robotcommand WHERE id=@id", conn);

//         cmd.Parameters.AddWithValue("id", id);

//         cmd.ExecuteNonQuery();
//     }
// }