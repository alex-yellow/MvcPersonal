using MvcPersonal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPersonal.Controllers
{
    public class PersonalController : Controller
    {
        PersonalContext db = new PersonalContext();
        public ActionResult Index(string searchstring, string department)
        {
            var personalList = new List<string>();
            var personalEl = from e in db.Personals orderby e.Department select e.Department;
            personalList.AddRange(personalEl.Distinct());
            var personal = from p in db.Personals select p;
            ViewBag.department = new SelectList(personalList);
            if (!String.IsNullOrEmpty(searchstring))
            {
                personal = personal.Where(p => p.Name.Contains(searchstring));
            }
            if (!String.IsNullOrEmpty(department))
            {
                personal = personal.Where(p => p.Department == department);
            }
            return View(personal);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Personal personal = db.Personals.Find(id);
            if(personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Personal personal)
        {
            db.Personals.Add(personal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Personal personal = db.Personals.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }
        [HttpPost]
        public ActionResult Edit(Personal personal)
        {
            db.Entry(personal).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Personal personal = db.Personals.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal personal = db.Personals.Find(id);
            db.Personals.Remove(personal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}