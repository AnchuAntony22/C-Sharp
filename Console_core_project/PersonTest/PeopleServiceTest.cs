using Console_core_project.Models.Data;
using Console_core_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class PeopleServiceTest
    {
        [Fact]
        public void Add_Person()
        {
            // Arrange
            var peopleService = new PeopleService();
            string firstName = "Anchu";
            string lastName = "Antony";

            // Act
            Person newPerson = peopleService.Add(firstName, lastName);

            // Assert
            Assert.Equal(1, peopleService.Size());
            Assert.Equal(firstName, newPerson.FirstName);
            Assert.Equal(lastName, newPerson.LastName);
        }
    }
}
