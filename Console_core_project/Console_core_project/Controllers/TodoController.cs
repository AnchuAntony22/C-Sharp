using Console_core_project.Data;
using Console_core_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Console_core_project.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoServiceDB _todoService;
        private readonly PeopleServiceDB _peopleService;

       
        public TodoController(TodoServiceDB todoService, PeopleServiceDB peopleService)
        {
            _todoService = todoService;
            _peopleService = peopleService;
        }

       
        public IActionResult Index()
        {
            var todos = _todoService.FindAll();
            return View(todos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var people = _peopleService.FindAll();
            var viewModel = new TodoCreateViewModel
            {
                Assignees = people.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.FirstName
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(TodoCreateViewModel viewModel)
        {
            // Re-populate the Assignees in case of validation errors
            viewModel.Assignees = _peopleService.FindAll().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.FirstName
            }).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    if (!viewModel.AssigneeId.HasValue)
                    {
                        ModelState.AddModelError(nameof(viewModel.AssigneeId), "Assignee is required.");
                    }
                    else
                    {
                        var assignee = _peopleService.FindById(viewModel.AssigneeId.Value);
                        if (assignee == null)
                        {
                            ModelState.AddModelError(nameof(viewModel.AssigneeId), "Selected assignee does not exist.");
                        }
                        else
                        {
                            var newTodo = new Todo
                            {
                                Description = viewModel.Description,
                                Assignee = assignee,
                                Done = false // Default value
                            };

                            _todoService.Add(newTodo.Description, newTodo.Assignee);
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            // Return view with validation errors
            return View(viewModel);
        }


        [HttpPost]

        public IActionResult Details(int id)
        {
            var todo = _todoService.FindById(id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

       
        public IActionResult Delete(int id)
        {
            var todo = _todoService.FindById(id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

       
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _todoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Unassigned()
        {
            var unassignedTodos = _todoService.FindUnassignedTodoItems();
            return View(unassignedTodos);
        }

       
        public IActionResult ByAssignee(int personId)
        {
            var todos = _todoService.FindByAssignee(personId);
            return View(todos);
        }

       
        public IActionResult ByStatus(bool doneStatus)
        {
            var todos = _todoService.FindByDoneStatus(doneStatus);
            return View(todos);
        }
    }
}
