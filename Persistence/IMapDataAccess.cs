using robot_controller_api.Models;
namespace robot_controller_api.Persistence;
public interface IMapDataAccess
{
    List<MapModel> GetMaps();
    MapModel? GetMapById(int id);
}