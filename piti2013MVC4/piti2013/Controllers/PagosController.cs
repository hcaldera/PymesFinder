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
    public class PagosController : Controller
    {
        private PymesFinder db = new PymesFinder();

        //
        // GET: /Pagos/

        public ActionResult Index()
        {
            var pagos = db.Pagos.Include(p => p.Servicios);
            return View(pagos.ToList());
        }

        //
        // GET: /Pagos/Details/5

        public ActionResult Details(int id = 0)
        {
            Pagos pagos = db.Pagos.Find(id);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            return View(pagos);
        }

        //
        // GET: /Pagos/Create

        public ActionResult Create()
        {
            ViewBag.serviciosID = new SelectList(db.Servicios, "serviciosID", "serviciosID");
            return View();
        }

        //
        // POST: /Pagos/Create

        [HttpPost]
        public ActionResult Create(Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                db.Pagos.Add(pagos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.serviciosID = new SelectList(db.Servicios, "serviciosID", "serviciosID", pagos.serviciosID);
            return View(pagos);
        }

        //
        // GET: /Pagos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pagos pagos = db.Pagos.Find(id);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            ViewBag.serviciosID = new SelectList(db.Servicios, "serviciosID", "serviciosID", pagos.serviciosID);
            return View(pagos);
        }

        //
        // POST: /Pagos/Edit/5

        [HttpPost]
        public ActionResult Edit(Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.serviciosID = new SelectList(db.Servicios, "serviciosID", "serviciosID", pagos.serviciosID);
            return View(pagos);
        }

        //
        // GET: /Pagos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pagos pagos = db.Pagos.Find(id);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            return View(pagos);
        }

        //
        // POST: /Pagos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagos pagos = db.Pagos.Find(id);
            db.Pagos.Remove(pagos);
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