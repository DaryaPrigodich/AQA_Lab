using Bogus;
using ConsoleApp1.Models;
using HW2.Factories;

namespace HW2
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*var employees = new PersonFactory().GetEmployee(4);
            
            employees.ForEach(u =>
            {
                /*Console.WriteLine(u.FullName);#1#
            });*/

           
            var person = new PersonFactory();

            var employees = person.GetEmployees(new Faker().Random.Int(1,5));
            var clients = person.GetCandidates(new Faker().Random.Int(1,5));
            
            employees.ForEach(u =>
                {
                    Console.WriteLine(u.FullName);
                });
            Console.WriteLine();
            
            clients.ForEach(u =>
            {
                Console.WriteLine(u.FullName);
            });
            /*var people = new UserFactory<Employee>();
            var a = people.User();*/
        }
    }
}

