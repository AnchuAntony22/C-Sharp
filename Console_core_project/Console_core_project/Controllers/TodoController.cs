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
            ViewBag.Assignees = people.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.FirstName
            }).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Todo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the full Person object for the selected Assignee
                    var assignee = _peopleService.FindById(model.Assignee.Id);
                    model.Assignee = assignee; // Set the Assignee property with the retrieved Person object

                    // Now you can add the todo item with the correct Assignee
                    _todoService.Add(model.Description, assignee);

                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            // If ModelState is not valid or an exception occurred, reload the view with necessary data
            var people = _peopleService.FindAll();
            ViewBag.Assignees = people.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.FirstName
            }).ToList();

            return View(model);
        }
    

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
