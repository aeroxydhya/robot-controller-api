namespace robot_controller_api.Models;

public class MapModel
{
    public int Id { get; set; }
    public int Columns { get; set; }
    public int Rows { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string? Description { get; set; }

    public MapModel() {}

    public MapModel(int id, int columns, int rows, string name,
        DateTime createdDate, DateTime modifiedDate, string? description)
    {
        Id = id;
        Columns = columns;
        Rows = rows;
        Name = name;
        CreatedDate = createdDate;
        ModifiedDate = modifiedDate;
        Description = description;
    }
}