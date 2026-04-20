namespace robot_controller_api.Models;

public class RobotCommandModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsMoveCommand { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string? Description { get; set; }

    public RobotCommandModel() {}

    public RobotCommandModel(int id, string name, bool isMoveCommand,
        DateTime createdDate, DateTime modifiedDate, string? description)
    {
        Id = id;
        Name = name;
        IsMoveCommand = isMoveCommand;
        CreatedDate = createdDate;
        ModifiedDate = modifiedDate;
        Description = description;
    }
}