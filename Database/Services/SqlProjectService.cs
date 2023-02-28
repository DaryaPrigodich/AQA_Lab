using Database.Databases;
using Database.Models;

namespace Database.Services;

public class SqlProjectService
{
    public Project? GetProjectBySuiteMode(int suiteMode)
    {
        using (var dbConnector = new DataBaseConnector())
        {
            return dbConnector.Project.FirstOrDefault(p => p.SuiteMode == suiteMode);
        }
    }
}
