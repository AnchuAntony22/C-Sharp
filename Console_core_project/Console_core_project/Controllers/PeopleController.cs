using Console_core_project.Data;
using Console_core_project.DataAccess;
using Console_core_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Console_core_project.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleServiceDB _peopleService;

        public PeopleController(PeopleServiceDB peopleService)
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
        public IActionResult Details(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Edit(model.Id, model.FirstName, model.LastName);
                    TempData["Message"] = "Person updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Please try again.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

    }



}
