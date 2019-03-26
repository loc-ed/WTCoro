using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WTCoro_AW.DAL;
using WTCoro_AW.Models;

namespace WTCoro_AW.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository _personRepository;
        public PersonController()
        {
            this._personRepository = new PersonRepository(new AdventureWorks2017Entities());
        }
        // GET: Person
        //operation 1 - show list of people
        public ActionResult Index()
        {
            var people_list = from Person in _personRepository.GetPeople()
                              select Person;
            return View(people_list);
        }

        //operation2  - show person details 
        //doesnt work 
        public ViewResult Details( int BusinessEntityID)
        {
            Person p = _personRepository.GetPersonByName(BusinessEntityID);
            return View(p);
        }

        //operation 3 - create new person
        public ActionResult Create()
        {
            return View(new Person());
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personRepository.InsertPerson(person);
                    _personRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.Contact System administrator");
            }
            return View(person);
        }

        //operation 4 - update book details 
        public ActionResult Edit(int BusinessEntityID)
        {
            Person person = _personRepository.GetPersonByName(BusinessEntityID);
            return View(person);
        }
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personRepository.UpdatePerson(person);
                    _personRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.Contact System Administrator");
            }
            return View(person);
        }

        //operation 5 - delete person 
        public ActionResult Delete(int BusinessEntityID, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes.Contact System Administrator";
            }
            Person person = _personRepository.GetPersonByName(BusinessEntityID);
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int BusinessEntityID)
        {
            try
            {
                Person person = _personRepository.GetPersonByName(BusinessEntityID);
                _personRepository.DeletePerson(BusinessEntityID);
                _personRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary
                    {
                        {"BusinessEntityID", BusinessEntityID },
                        {"saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }


    }
}