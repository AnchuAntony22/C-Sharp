using Console_core_project.DataAccess;
using Console_core_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            return _context.People.Count(); 
        }

        public Person[] FindAll()
        {
            return _context.People.ToArray(); 
        }

        public Person FindById(int personId)
        {
            return _context.People.Find(personId); 
        }

        //public Person Add(string firstName, string lastName)
        //{
        //    int newId = PersonSequencer.NextPersonId();
        //    var newPerson = new Person(newId, firstName, lastName);

        //    _context.People.Add(newPerson); 
        //    _context.SaveChanges(); 
        //    return newPerson;
        //}
        public Person Add(string firstName, string lastName)
        {
            var newPerson = new Person(firstName, lastName);

            _context.People.Add(newPerson);
            _context.SaveChanges();
            return newPerson;
        }


        //public void Clear()
        //{
        //    _context.People.RemoveRange(_context.People); 
        //    _context.SaveChanges();
        //}
        public void Clear()
        {
            _context.People.RemoveRange(_context.People);
            _context.Database.ExecuteSqlRaw("ALTER TABLE People AUTO_INCREMENT = 1;");
            _context.SaveChanges();
        }

        public void Remove(int personId)
        {
            var person = _context.People.Find(personId);
            if (person != null)
            {
                _context.People.Remove(person); 
                _context.SaveChanges();
            }
        }
        public void Edit(int id, string firstName, string lastName)
        {
            var person = _context.People.Find(id);
            if (person == null)
            {
                throw new ArgumentException("Person not found");
            }

            person.FirstName = firstName;
            person.LastName = lastName;
            _context.People.Update(person);
            _context.SaveChanges();
            Debug.WriteLine("Person updated successfully: " + person.FirstName + " " + person.LastName);
        }

        //public void Edit(int id, string firstName, string lastName)
        //{
        //    var person = _context.People.Find(id);
        //    if (person == null)
        //    {
        //        throw new ArgumentException("Person not found");
        //    }

        //    person.FirstName = firstName;
        //    person.LastName = lastName;
        //    _context.People.Update(person);
        //    _context.SaveChanges();
        //}
    }

}
