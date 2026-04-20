using Microsoft.AspNetCore.Mvc;
using robot_controller_api.Models;
using robot_controller_api.Persistence;

namespace robot_controller_api.Controllers;

[ApiController]
[Route("api/maps")]
public class MapsController : ControllerBase
{
    private readonly IMapDataAccess _repo;

    public MapsController(IMapDataAccess repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IEnumerable<MapModel> GetAllMaps()
    {
        return _repo.GetMaps();
    }

    [HttpGet("{id}")]
    public IActionResult GetMapById(int id)
    {
        var map = _repo.GetMapById(id);

        if (map == null)
            return NotFound();

        return Ok(map);
    }
}