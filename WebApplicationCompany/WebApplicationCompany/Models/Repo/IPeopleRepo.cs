﻿using WebApplicationCompany.Models.Entities;

namespace WebApplicationCompany.Models.Repo
{
    public interface IPeopleRepo
    {
        Person Create(Person person);
        List<Person> Read();
        Person Read(int id);
        bool Update(Person person);
        bool Delete(Person person);
    }
}
