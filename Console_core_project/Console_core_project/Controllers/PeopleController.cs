using Console_core_project.Data;
using Console_core_project.DataAccess;
using Console_core_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Console_core_project.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index()
        {
            var people = _peopleService.FindAll();
            return View(people);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string firstName, string lastName)
        {
            try
            {
                _peopleService.Add(firstName, lastName);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _peopleService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
