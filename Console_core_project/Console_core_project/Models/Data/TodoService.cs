namespace Console_core_project.Models.Data
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
    }
}
