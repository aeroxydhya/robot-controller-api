using robot_controller_api.Models;
using robot_controller_api.Persistence;

namespace robot_controller_api.DataAccess
{
    public class MapEF : IMapDataAccess
    {
        private readonly RobotContext _context;

        public MapEF(RobotContext context)
        {
            _context = context;
        }

        public List<MapModel> GetMaps()
        {
            return _context.Maps
                .Select(m => new MapModel(m.Id, m.Columns, m.Rows, m.Name, m.Createddate, m.Modifieddate, m.Description))
                .ToList();
        }

        public MapModel? GetMapById(int id)
        {
            var m = _context.Maps.FirstOrDefault(x => x.Id == id);
            return m == null ? null : new MapModel(m.Id, m.Columns, m.Rows, m.Name, m.Createddate, m.Modifieddate, m.Description);
        }
    }
}