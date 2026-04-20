using robot_controller_api.Models;

namespace robot_controller_api.Persistence;

public interface IRobotCommandDataAccess
{
    List<RobotCommandModel> GetRobotCommands();
    RobotCommandModel? GetRobotCommandById(int id);
    void AddRobotCommand(RobotCommandModel command);
    void UpdateRobotCommand(int id, RobotCommandModel command);
    void DeleteRobotCommand(int id);
}