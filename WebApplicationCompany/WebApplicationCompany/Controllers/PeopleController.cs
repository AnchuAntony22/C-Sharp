using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationCompany.Models;
using WebApplicationCompany.Models.Repo;
using WebApplicationCompany.Models.Viewmodel;

namespace WebApplicationCompany.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        public IActionResult Index(string searchString)
        {
            var viewModel = new PeopleViewModel
            {
                Search = searchString
            };

            if (string.IsNullOrEmpty(searchString))
            {
                viewModel.People = _peopleService.All();
            }
            else
            {
                viewModel.People = _peopleService.Search(searchString);
            }

            return View(viewModel);
            ;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(person);
                return RedirectToAction("Index");
            }

            return View(person);
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

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _peopleService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
