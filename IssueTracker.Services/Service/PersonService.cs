using IssueTracker.Data;
using IssueTracker.Data.Domain;
using IssueTracker.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Services.Service
{
    public class PersonService : IPersonService
    {
        private IssueTrackerContext _context;
        public PersonService(IssueTrackerContext context)
        {
            _context = context;
        }

        public void Add(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void AssignRole(string role, int id)
        {
            Person person = Get(id);
            person.Role = role;
            _context.SaveChanges();
        }

        public string CreateUsername(string firstName, string lastName)
        {
            IList<Person> persons = GetAll();
            foreach (Person person in persons)
            {
                if (firstName + " " + lastName == person.UserName)
                {
                    return firstName + " " + lastName + person.ID.ToString();
                }

            }
            return firstName + " " + lastName;
        }

        public Person Get(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return GetAll().FirstOrDefault(p => p.ID == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IList<Person> GetAll()
        {
            return _context.Person.Include(p => p.Project).ToList();
        }

        public IList<Person> GetPersonsWithProject(int projectID)
        {
            return GetAll().Where(p => p.ProjectID == projectID).ToList();
        }

        public IList<Person> GetRolelessPeople()
        {
            IList<Person> people = GetAll().Where(person => person.Role == null).ToList();
            return people;
        }

        public void Remove(Person person)
        {
            _context.Person.Remove(person);
            _context.SaveChanges();
        }

        public void RemoveRole(int id)
        {
            Person person = Get(id);
            person.Role = null;
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            Person personToUpdate = Get(person.ID);
            _context.Person.Update(personToUpdate).CurrentValues.SetValues(person);
            _context.SaveChanges();
        }
    }
}
