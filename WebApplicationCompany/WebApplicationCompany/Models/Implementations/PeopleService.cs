﻿using WebApplicationCompany.Models.Entities;
using WebApplicationCompany.Models.Repo;
using WebApplicationCompany.Models.Viewmodel;

namespace WebApplicationCompany.Models.Implementations
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;

        }
        //IPeopleRepo _peopleRepo;

        //public PeopleService()
        //{
        //    //_peopleRepo = peopleRepo;
        //    _peopleRepo = new InMemoryPeopleRepo();
        //}
        public Person Add(CreatePersonViewModel person)
        {

            var newPerson = new Person(person.Name, person.PhoneNumber, person.City);
            return _peopleRepo.Create(newPerson);
            throw new NotImplementedException();
        }


        public List<Person> All()
        {
            return _peopleRepo.Read();
            throw new NotImplementedException();
        }
        public Person FindById(int id)
        {
            return _peopleRepo.Read(id);
            throw new NotImplementedException();
        }


        public bool Edit(int id, CreatePersonViewModel person)
        {
            var existingPerson = FindById(id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.PhoneNumber = person.PhoneNumber;
                existingPerson.City = person.City;
                return _peopleRepo.Update(existingPerson);
            }
            return false;
            throw new NotImplementedException();
        }

       
        public bool Remove(int id)
        {
            var person = FindById(id);
            if (person != null)
            {
                return _peopleRepo.Delete(person);
            }
            return false;
            throw new NotImplementedException();
        }

        public List<Person> Search(string search)
        {
            return _peopleRepo.Read().Where(p => p.Name.ToLower().Contains(search.ToLower()) || p.City.ToLower().Contains(search.ToLower())).ToList();
            throw new NotImplementedException();
        }
    }
}
