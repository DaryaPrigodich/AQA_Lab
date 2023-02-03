using pageObject.Enums;

namespace pageObject.Models;

public class Project
{
    public string Name { get; set; }
    public string Announcement { get; set; }
    public ProjectType Type { get; set; }
}
