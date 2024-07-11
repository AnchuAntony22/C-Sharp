using Console_core_project.Models;

namespace Console_core_project.Data
{
    public class TodoService
    {
        private static Todo[] todos = new Todo[0];
        public int Size()
        {

            return todos.Length;
        }
        public Todo[] FindAll()
        {

            return todos;
        }
        public Todo FindById(int todoId)
        {

            return Array.Find(todos, t => t.Id == todoId);
        }
        public Todo Add(string description)
        {

            int newId = TodoSequencer.NexttodoId();
            Todo newtoDo = new Todo(newId, description);

            Todo[] newtodos = new Todo[todos.Length + 1];
            Array.Copy(todos, newtodos, todos.Length);
            newtodos[todos.Length] = newtoDo;
            todos = newtodos;

            return newtoDo;
        }
        public void Clear()
        {
            todos = new Todo[0];
        }
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            return todos.Where(t => t.Done == doneStatus).ToArray();
        }

        public Todo[] FindByAssignee(int personId)
        {
            return todos.Where(t => t.Assignee?.Id == personId).ToArray();
        }
        public Todo[] FindByAssignee(Person assignee)
        {
            if (assignee == null)
            {
                throw new ArgumentNullException(nameof(assignee));
            }
            return todos.Where(t => t.Assignee == assignee).ToArray();
        }
        public Todo[] FindUnassignedTodoItems()
        {
            return todos.Where(t => t.Assignee == null).ToArray();
        }
        public void Remove(int todoId)
        {
            todos = todos.Where(t => t.Id != todoId).ToArray();
        }
    }
}
