using System.ComponentModel.DataAnnotations;

namespace Console_core_project.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; private set; }  

        private string description;
        private bool done;
        private Person assignee;

        public Todo() { }
        public Todo(int id, string description, Person assignee = null)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Description cannot be null or empty");
            this.Id = id;  
            this.description = description;
            this.done = false;
            this.assignee = assignee;
        }

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

        [Required(ErrorMessage = "Please select an assignee.")]
        public int? AssigneeId { get; set; }  

        public Person Assignee
        {
            get => assignee;
            set => assignee = value;
        }
    }
}
