using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using piti2013.Models;

namespace piti2013.Controllers
{
    public class EstatusController : Controller
    {
        private PymesFinder db = new PymesFinder();

        //
        // GET: /Estatus/

        public ActionResult Index()
        {
            return View(db.Estatus.ToList());
        }

        //
        // GET: /Estatus/Details/5

        public ActionResult Details(int id = 0)
        {
            Estatus estatus = db.Estatus.Find(id);
            if (estatus == null)
            {
                return HttpNotFound();
            }
            return View(estatus);
        }

        //
        // GET: /Estatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Estatus/Create

        [HttpPost]
        public ActionResult Create(Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                db.Estatus.Add(estatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estatus);
        }

        //
        // GET: /Estatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Estatus estatus = db.Estatus.Find(id);
            if (estatus == null)
            {
                return HttpNotFound();
            }
            return View(estatus);
        }

        //
        // POST: /Estatus/Edit/5

        [HttpPost]
        public ActionResult Edit(Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estatus);
        }

        //
        // GET: /Estatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Estatus estatus = db.Estatus.Find(id);
            if (estatus == null)
            {
                return HttpNotFound();
            }
            return View(estatus);
        }

        //
        // POST: /Estatus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Estatus estatus = db.Estatus.Find(id);
            db.Estatus.Remove(estatus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}