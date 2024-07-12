using Console_core_project.Models;

namespace Console_core_project.Data
{
    public class PeopleService
    {
        private static Person[] people = new Person[0];

        public int Size()
        {

            return people.Length;
        }
        public Person[] FindAll()
        {

            return people;
        }
        public Person FindById(int personId)
        {

            return Array.Find(people, p => p.Id == personId);
        }
        public Person Add(string firstName, string lastName)
        {
            //int newId = PersonSequencer.NextPersonId();
            Person newPerson = new Person(firstName, lastName);

            Person[] newPeople = new Person[people.Length + 1];
            Array.Copy(people, newPeople, people.Length);
            newPeople[people.Length] = newPerson;
            people = newPeople;

            return newPerson;
        }
        public void Clear()
        {
            people = new Person[0];
        }
        public void Remove(int personId)
        {
            people = people.Where(p => p.Id != personId).ToArray();
        }
    }


}

