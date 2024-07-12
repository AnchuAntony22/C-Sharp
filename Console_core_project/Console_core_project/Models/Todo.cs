using System.ComponentModel.DataAnnotations;

namespace Console_core_project.Models
{
    public class Todo
    {
        [Key]
        public int id { get; private set; }
        //private readonly int id;
        private string description;
        private bool done;
        private Person assignee;
        private Todo() { }
        public Todo(int id, string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Description cannot be null or empty");
            this.id = id;
            this.description = description;
            this.done = false;
            this.assignee = null;

        }
        public int Id => id;
        public string Description
        {
            get => description; 
            set => description = string.IsNullOrEmpty(value) ? throw new ArgumentException("Description cannot be null or empty") : value;

        }
        public bool Done
        {
            get => done;
            set => done = value;
        }
        public Person Assignee
        {
            get => assignee;
            set => assignee = value;
        }
    }
}
