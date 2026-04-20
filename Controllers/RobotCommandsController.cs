using Microsoft.AspNetCore.Mvc;
using robot_controller_api.Models;
using robot_controller_api.Persistence;

namespace robot_controller_api.Controllers;

[ApiController]
[Route("api/robot-commands")]
public class RobotCommandsController : ControllerBase
{
    private readonly IRobotCommandDataAccess _repo;

    public RobotCommandsController(IRobotCommandDataAccess repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IEnumerable<RobotCommandModel> GetAllRobotCommands()
    {
        return _repo.GetRobotCommands();
    }

    [HttpGet("{id}")]
    public IActionResult GetRobotCommandById(int id)
    {
        var command = _repo.GetRobotCommandById(id);

        if (command == null)
            return NotFound();

        return Ok(command);
    }

    [HttpPost]
    public IActionResult AddRobotCommand(RobotCommandModel command)
    {
        _repo.AddRobotCommand(command);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRobotCommand(int id, RobotCommandModel command)
    {
        _repo.UpdateRobotCommand(id, command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRobotCommand(int id)
    {
        _repo.DeleteRobotCommand(id);
        return NoContent();
    }
}