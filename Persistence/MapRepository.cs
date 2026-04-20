// using Npgsql;
// using robot_controller_api.Models;

// namespace robot_controller_api.Persistence;

// public class MapRepository :
//     IMapDataAccess, IRepository
// {
//     private IRepository _repo => this;

//     public List<MapModel> GetMaps()
//     {
//         return _repo.ExecuteReader<MapModel>(
//             "SELECT * FROM map");
//     }

//     public MapModel? GetMapById(int id)
//     {
//         var parameters = new NpgsqlParameter[]
//         {
//             new("id", id)
//         };

//         return _repo.ExecuteReader<MapModel>(
//             "SELECT * FROM map WHERE id=@id",
//             parameters).FirstOrDefault();
//     }
// }