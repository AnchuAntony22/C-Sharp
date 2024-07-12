using Console_core_project.Data;
using Console_core_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Console_core_project.Controllers
{
    public class TodosController : Controller
    {
        private readonly TodoService _todoService;
        private readonly PeopleService _peopleService;

       
        public TodosController(TodoService todoService, PeopleService peopleService)
        {
            _todoService = todoService;
            _peopleService = peopleService;
        }

       
        public IActionResult Index()
        {
            var todos = _todoService.FindAll();
            return View(todos);
        }

        
        public IActionResult Create()
        {
            ViewBag.Assignees = _peopleService.FindAll();
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Todo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _todoService.Add(model.Description, model.Assignee);
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

           
            ViewBag.Assignees = _peopleService.FindAll();
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
