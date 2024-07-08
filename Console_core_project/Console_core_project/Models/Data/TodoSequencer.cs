namespace Console_core_project.Models.Data
{
    public class TodoSequencer
    {
        private static int todo = 0;
        public static int Nexttodo()
        {
            return ++todo;

        }
        public static void Reset()
        {
            todo = 0;
        }

    }
}
