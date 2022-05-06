using Nerddinner;
using Nerddinner.Model;
using NerdDinner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Controllers
{
    public class DinnerController : Controller
    {
        IDinnerRepository _repository;
        public DinnerController()
        {
            _repository = new SqlDinnerRepository();
        }
        public DinnerController(IDinnerRepository repository)
        {
            _repository = repository;
        }
        // GET: Dinner
        public ActionResult Index()
        {
            var dinners = _repository.FindAllDinners().Where(x => x.EventData > DateTime.Now).ToList();
            return View(dinners);
        }

        // GET: Dinner/Details/5
        public ActionResult Details(int id)
        {
            var dinner = _repository.GetDinner(id);
            return View(dinner);
        }

        // GET: Dinner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dinner/Create
        [HttpPost]
        public ActionResult Create(Dinner dinner)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    _repository.Add(dinner);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(dinner);
                }
            }
            else
            {
                return View(dinner);
            }
        }

        // GET: Dinner/Edit/5
        public ActionResult Edit(int id)
        {
            var dinner = _repository.GetDinner(id);
            return View(dinner);
        }

        // POST: Dinner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var dinner = _repository.GetDinner(id);
            return View(dinner);
        
            try
            {
                // TODO: Add update logic here
                _repository.Update(dinner);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dinner);
            }
        }

        // GET: Dinner/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new DB();
            var dinner = db.Dinners.SingleOrDefault(x => x.DinnerID == id);
            return View(dinner);
        }

        // POST: Dinner/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
