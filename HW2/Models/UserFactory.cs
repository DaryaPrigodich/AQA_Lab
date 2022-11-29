using Bogus;
using ConsoleApp1.Models;
using HW2.Factories;

namespace HW2;

public class UserFactory <T>
{
    public T User( )
    {
        if (T == Employee)
        {
            var person = new PersonFactory();
            var employee = person.GetEmployees(1);
        }
        else
        {
            var person = new PersonFactory();
            var candidate = person.GetCandidates(1);
        }
    }
}