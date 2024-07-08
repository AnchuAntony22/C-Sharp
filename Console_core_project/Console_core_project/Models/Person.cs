﻿namespace Console_core_project.Models
{
    public class Person
    {
        private readonly int id;
        private string firstName;
        private string lastName;

        public Person(int id, string firstName, string lastName)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => firstName;
            set => firstName = string.IsNullOrEmpty(value) ? throw new ArgumentException("FirstName cannot be null or empty") : value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = string.IsNullOrEmpty(value) ? throw new ArgumentException("LastName cannot be null or empty") : value;
        }

        public int Id => id;
    }

}
