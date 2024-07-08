using Console_core_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class TodoTests
    {
      
        [Fact]
        public void Description_Null()
        {
            // Arrange
            int id = 1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Todo(id, null));
        }

        [Fact]
        public void Description_Empty()
        {
            // Arrange
            int id = 1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Todo(id, ""));
        }

    }
}
