using IssueTracker.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Services.IService
{
    public interface IPersonService
    {
        void Add(Person person);

        void Remove(Person person);

        void Update(Person person);

        Person Get(int id);

        IList<Person> GetAll();

        IList<Person> GetPersonsWithProject(int projectID);

        string CreateUsername(string firstName, string lastName);

        IList<Person> GetRolelessPeople();

        void AssignRole(string role, int id);

        void RemoveRole(int id);



    }
}
