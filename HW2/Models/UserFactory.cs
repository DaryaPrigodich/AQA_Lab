using ConsoleApp1.Models;
using HW2.Factories;

namespace HW2;

public class UserFactory
{
    public T GetUser<T>() where T : Person
    {
        return typeof(T) == typeof(Employee) ? new PersonFactory().GetEmployees(1).First() : new PersonFactory().GetCandidates(1).First();
    }
}
