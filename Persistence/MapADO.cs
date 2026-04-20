// using Npgsql;
// using robot_controller_api.Models;

// namespace robot_controller_api.Persistence;

// public class MapADO : IMapDataAccess
// {
//     private const string CONNECTION_STRING =
//     "Host=localhost;Username=postgres;Password=Pass123;Database=sit331";

//     public List<MapModel> GetMaps()
//     {
//         var maps = new List<MapModel>();

//         using var conn = new NpgsqlConnection(CONNECTION_STRING);
//         conn.Open();

//         using var cmd = new NpgsqlCommand("SELECT * FROM map", conn);
//         using var dr = cmd.ExecuteReader();

//         while (dr.Read())
//         {
//             maps.Add(new MapModel(
//                 (int)dr["id"],
//                 (int)dr["columns"],
//                 (int)dr["rows"],
//                 (string)dr["Name"],
//                 (DateTime)dr["createddate"],
//                 (DateTime)dr["modifieddate"],
//                 dr["description"] as string
//             ));
//         }

//         return maps;
//     }

//     public MapModel? GetMapById(int id)
//     {
//         using var conn = new NpgsqlConnection(CONNECTION_STRING);
//         conn.Open();

//         using var cmd =
//         new NpgsqlCommand("SELECT * FROM map WHERE id=@id", conn);

//         cmd.Parameters.AddWithValue("id", id);

//         using var dr = cmd.ExecuteReader();

//         if (dr.Read())
//         {
//             return new MapModel(
//                 (int)dr["id"],
//                 (int)dr["columns"],
//                 (int)dr["rows"],
//                 (string)dr["Name"],
//                 (DateTime)dr["createddate"],
//                 (DateTime)dr["modifieddate"],
//                 dr["description"] as string
//             );
//         }

//         return null;
//     }
// }