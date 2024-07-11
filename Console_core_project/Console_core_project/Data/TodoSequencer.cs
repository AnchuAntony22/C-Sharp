namespace Console_core_project.Data
{
    public class TodoSequencer
    {
        private static int todoId = 0;
        public static int NexttodoId()
        {
            return ++todoId;

        }
        public static void Reset()
        {
            todoId = 0;
        }

    }
}
