using Console_core_project.DataAccess;
using Console_core_project.Models;

namespace Console_core_project.Data
{
    public class PeopleServiceDB
    {
        private readonly TodoDbContext _context;

        public PeopleServiceDB(TodoDbContext context)
        {
            _context = context;
        }

        public int Size()
        {
            return _context.People.Count(); // Use EF Core for counting
        }

        public Person[] FindAll()
        {
            return _context.People.ToArray(); // Use EF Core to retrieve all people
        }

        public Person FindById(int personId)
        {
            return _context.People.Find(personId); // Use EF Core to find by ID
        }

        public Person Add(string firstName, string lastName)
        {
            int newId = PersonSequencer.NextPersonId();
            var newPerson = new Person(newId, firstName, lastName);

            _context.People.Add(newPerson); // Add person to context
            _context.SaveChanges(); // Save changes to database
            return newPerson;
        }


        public void Clear()
        {
            _context.People.RemoveRange(_context.People); // Remove all people using EF Core
            _context.SaveChanges();
        }

        public void Remove(int personId)
        {
            var person = _context.People.Find(personId);
            if (person != null)
            {
                _context.People.Remove(person); // Remove specific person using EF Core
                _context.SaveChanges();
            }
        }
    }

}
