using Console_core_project.DataAccess;
using Console_core_project.Models;

namespace Console_core_project.Data
{
    public class TodoServiceDB
    {
        private readonly TodoDbContext _context;

        public TodoServiceDB(TodoDbContext context)
        {
            _context = context;
        }

        public int Size()
        {
            return _context.Todos.Count();
        }

        public Todo[] FindAll()
        {
            return _context.Todos.ToArray();
        }

        public Todo FindById(int todoId)
        {
            return _context.Todos.Find(todoId);
        }

        public Todo Add(string description)
        {
            int newId = TodoSequencer.NexttodoId();
            Todo newTodo = new Todo(newId, description); // Pass both id and description

            _context.Todos.Add(newTodo);
            _context.SaveChanges();

            return newTodo;
        }


        public void Clear()
        {
            _context.Todos.RemoveRange(_context.Todos);
            _context.SaveChanges();
        }

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            return _context.Todos.Where(t => t.Done == doneStatus).ToArray();
        }

        public Todo[] FindByAssignee(int personId)
        {
            return _context.Todos.Where(t => t.Assignee != null && t.Assignee.Id == personId).ToArray();
        }


        public Todo[] FindByAssignee(Person assignee)
        {
            if (assignee == null)
            {
                throw new ArgumentNullException(nameof(assignee));
            }
            return _context.Todos.Where(t => t.Assignee == assignee).ToArray();
        }

        public Todo[] FindUnassignedTodoItems()
        {
            return _context.Todos.Where(t => t.Assignee == null).ToArray();
        }

        public void Remove(int todoId)
        {
            var todo = _context.Todos.Find(todoId);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
        }
    }
}
