# Task:
1. You need to create users:

   - Candidate(looking for a job) - Guid Id, first name, last name, desired position, brief description of the position, salary.
   
   - Employee(holds any position in any company) - Guid Id, first name, last name, position, brief description of the position, salary; company they work, country, city and physical address of the company.

2. Create and implement an interface that will contain a method that outputs user data to the console.
   Example:
   
   - "Hello, I am {FullName} I want to be a {JobTittle}({JobDescriptor}) with a salary from {JobSalary}."
   
   - "Hello, I am {FullName}, {JobTittle} in {CompanyName}({CompanyCountry}), {CompanyCity}, {CompanyStreet} and my salary {JobSalary}."

3. Fill in all data about users and companies using the library **Bogus**.

4. Implement the creation of a random quantity Candidate, Employee.

5. Create a class UserFactory, which depends on the type of user (Candidate, Employee) will return the required object.
