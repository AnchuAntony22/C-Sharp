using Microsoft.AspNetCore.Mvc.Rendering;

namespace Console_core_project.Models
{
    public class TodoCreateViewModel
    {
        
            public string Description { get; set; }
            public int? AssigneeId { get; set; }
            public IEnumerable<SelectListItem> Assignees { get; set; }
        

    }
}
