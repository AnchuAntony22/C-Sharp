namespace UnitTest
{
    public class PersonTests
    {
        [Fact]
        public void FirstName_Null()
        {
            //Arrange
            int id = 1;
            string lastName = "Antony";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Console_core_project.Models.Person(id, null, lastName));

                
        }
        [Fact]
        public void FirstName_empty()
        {
            //Arrange
            int id = 1;
            string lastName = "Antony";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Console_core_project.Models.Person(id, " ", lastName));


        }
        [Fact]
        public void LastName_Null()
        {
            //Arrange
            int id = 1;
            string firstName = "Antony";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Console_core_project.Models.Person(id, firstName, null));


        }
        [Fact]
        public void LastName_empty()
        {
            //Arrange
            int id = 1;
            string firstName = "Antony";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Console_core_project.Models.Person(id, firstName, " "));


        }
    }
}