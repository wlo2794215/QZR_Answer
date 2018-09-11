using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Answer.Model.Answer;
using Answer.Models;

namespace Answer.Controllers
{
    public class EmoloyeesController : Controller
    {
        private AnswerContext db = new AnswerContext();

        // GET: Emoloyees
        public ActionResult Index()
        {
            var result = from m in db.Emoloyees
                         select m;
            
            return View(result);
        }

        // GET: Emoloyees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emoloyee emoloyee = db.Emoloyees.Find(id);
            if (emoloyee == null)
            {
                return HttpNotFound();
            }
            return View(emoloyee);
        }

        // GET: Emoloyees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emoloyees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Gender,Birthday")] Emoloyee emoloyee)
        {
            if (ModelState.IsValid)
            {
                db.Emoloyees.Add(emoloyee);
                db.SaveChanges();
            }
            return RedirectToAction("SelectSQL");
        }

        // GET: Emoloyees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emoloyee emoloyee = db.Emoloyees.Find(id);
            if (emoloyee == null)
            {
                return HttpNotFound();
            }
            return View(emoloyee);
        }

        // POST: Emoloyees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Gender,Birthday")] Emoloyee emoloyee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emoloyee).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("SelectSQL");
        }

        // GET: Emoloyees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emoloyee emoloyee = db.Emoloyees.Find(id);
            if (emoloyee == null)
            {
                return HttpNotFound();
            }
            return View(emoloyee);
        }

        // POST: Emoloyees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emoloyee emoloyee = db.Emoloyees.Find(id);
            db.Emoloyees.Remove(emoloyee);
            db.SaveChanges();
            return RedirectToAction("SelectSQL");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public ActionResult SelectSQL(String SearchString)
        {
            var result = from m in db.Emoloyees
                         select m;
            if (!String.IsNullOrEmpty(SearchString))
            {
                result = result.Where(a => a.Name.Contains(SearchString));
            }
            return PartialView(result);
        }
    }
}
