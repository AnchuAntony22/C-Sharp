using Console_core_project.Models.Data;
using Console_core_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class TodoServiceTest
    {
        [Fact]
        public void Add_Todo()
        {
            // Arrange
            var todoService = new TodoService();
            string description = "it is a description";

            // Act
            Todo newTodo = todoService.Add(description);

            // Assert
            Assert.Equal(1, todoService.Size());
            Assert.Equal(description, newTodo.Description);
        }
    }
}
