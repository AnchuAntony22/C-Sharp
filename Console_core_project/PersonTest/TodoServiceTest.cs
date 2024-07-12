using Console_core_project.Data;
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
        private TodoService todoService;

        public TodoServiceTest()
        {
            todoService = new TodoService();
        }

        [Fact]
        public void Add_Todo()
        {
            // Arrange
            string description = "it is a description";
            var assignee = new Person(PersonSequencer.NextPersonId(), "First", "Last");
            // Act
            Todo newTodo = todoService.Add(description, assignee);

            // Assert
            Assert.Equal(1, todoService.Size());
            Assert.Equal(description, newTodo.Description);
            Assert.Equal(assignee, newTodo.Assignee);

            todoService.Clear();
        }

        [Fact]
        public void FindById_TodoExists()
        {
            // Arrange
            var todo = todoService.Add("Description 1", new Person(PersonSequencer.NextPersonId(), "First", "Last"));

            // Act
            Todo foundTodo = todoService.FindById(todo.Id);

            // Assert
            Assert.Equal(todo, foundTodo);

            
            todoService.Clear();
        }

        [Fact]
        public void FindById_TodoDoesNotExist()
        {
            // Act
            Todo foundTodo = todoService.FindById(999);

            // Assert
            Assert.Null(foundTodo);
        }

        [Fact]
        public void FindAll_ReturnsAllTodos()
        {
            // Arrange
            todoService.Add("Description 1", new Person(PersonSequencer.NextPersonId(), "First", "Last"));
            todoService.Add("Description 2", new Person(PersonSequencer.NextPersonId(), "First", "Last"));

            // Act
            Todo[] allTodos = todoService.FindAll();

            // Assert
            Assert.Equal(2, allTodos.Length);

           
            todoService.Clear();
        }

        [Fact]
        public void Clear_RemovesAllTodos()
        {
            // Arrange
            todoService.Add("Description 1", new Person(PersonSequencer.NextPersonId(), "First", "Last"));
            todoService.Add("Description 2", new Person(PersonSequencer.NextPersonId(), "First", "Last"));

            // Act
            todoService.Clear();

            // Assert
            Assert.Equal(0, todoService.Size());
            Assert.Empty(todoService.FindAll());
        }

        [Fact]
        public void FindByDoneStatus_ReturnsCorrectTodos()
        {
            // Arrange
            var todo1 = todoService.Add("Description 1", new Person(PersonSequencer.NextPersonId(), "First", "Last"));
            todo1.Done = true;
            var todo2 = todoService.Add("Description 2", new Person(PersonSequencer.NextPersonId(), "First", "Last"));

            // Act
            Todo[] doneTodos = todoService.FindByDoneStatus(true);

            // Assert
            Assert.Single(doneTodos);
            Assert.Equal(todo1, doneTodos[0]);

           
            todoService.Clear();
        }

        [Fact]
        public void FindByAssignee_ById_ReturnsCorrectTodos()
        {
            // Arrange
            var person = new Person(PersonSequencer.NextPersonId(), "First", "Last");
            var todo1 = todoService.Add("Description 1",person);
            todo1.Assignee = person;
            var todo2 = todoService.Add("Description 2", person);

            // Act
            Todo[] assignedTodos = todoService.FindByAssignee(person.Id);

            // Assert
            Assert.Single(assignedTodos);
            Assert.Equal(todo1, assignedTodos[0]);

           
            todoService.Clear();
        }

        [Fact]
        public void FindByAssignee_ByPerson_ReturnsCorrectTodos()
        {
            // Arrange
            var person = new Person(PersonSequencer.NextPersonId(), "First", "Last");
            var todo1 = todoService.Add("Description 1",person);
            todo1.Assignee = person;
            var todo2 = todoService.Add("Description 2",person);

            // Act
            Todo[] assignedTodos = todoService.FindByAssignee(person);

            // Assert
            Assert.Single(assignedTodos);
            Assert.Equal(todo1, assignedTodos[0]);

            todoService.Clear();
        }

        [Fact]
        public void FindUnassignedTodoItems_ReturnsCorrectTodos()
        {
            // Arrange
            var todo1 = todoService.Add("Description 1", new Person(PersonSequencer.NextPersonId(), "First", "Last"));
            var todo2 = todoService.Add("Description 2", new Person(PersonSequencer.NextPersonId(), "First", "Last"));
            todo2.Assignee = new Person(PersonSequencer.NextPersonId(), "First", "Last");

            // Act
            Todo[] unassignedTodos = todoService.FindUnassignedTodoItems();

            // Assert
            Assert.Single(unassignedTodos);
            Assert.Equal(todo1, unassignedTodos[0]);

           
            todoService.Clear();
        }
    }
}
