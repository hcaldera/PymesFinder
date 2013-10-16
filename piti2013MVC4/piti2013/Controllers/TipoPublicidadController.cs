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
    public class TipoPublicidadController : Controller
    {
        private PymesFinder db = new PymesFinder();

        //
        // GET: /TipoPublicidad/

        public ActionResult Index()
        {
            return View(db.TipoPublicidad.ToList());
        }

        //
        // GET: /TipoPublicidad/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoPublicidad tipopublicidad = db.TipoPublicidad.Find(id);
            if (tipopublicidad == null)
            {
                return HttpNotFound();
            }
            return View(tipopublicidad);
        }

        //
        // GET: /TipoPublicidad/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoPublicidad/Create

        [HttpPost]
        public ActionResult Create(TipoPublicidad tipopublicidad)
        {
            if (ModelState.IsValid)
            {
                db.TipoPublicidad.Add(tipopublicidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipopublicidad);
        }

        //
        // GET: /TipoPublicidad/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoPublicidad tipopublicidad = db.TipoPublicidad.Find(id);
            if (tipopublicidad == null)
            {
                return HttpNotFound();
            }
            return View(tipopublicidad);
        }

        //
        // POST: /TipoPublicidad/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoPublicidad tipopublicidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipopublicidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipopublicidad);
        }

        //
        // GET: /TipoPublicidad/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoPublicidad tipopublicidad = db.TipoPublicidad.Find(id);
            if (tipopublicidad == null)
            {
                return HttpNotFound();
            }
            return View(tipopublicidad);
        }

        //
        // POST: /TipoPublicidad/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPublicidad tipopublicidad = db.TipoPublicidad.Find(id);
            db.TipoPublicidad.Remove(tipopublicidad);
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