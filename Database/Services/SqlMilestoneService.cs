using Database.Databases;
using Database.Models;

namespace Database.Services;

public class SqlMilestoneService
{
    public Milestone GetMilestoneById(int milestoneId)
    {
        using (var dbConnector = new DataBaseConnector())
        {
            return dbConnector.Milestone.FirstOrDefault(m=>m.Id==milestoneId);
        }
    }
}
