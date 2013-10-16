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
    public class TipoServicioController : Controller
    {
        private PymesFinder db = new PymesFinder();

        //
        // GET: /TipoServicio/

        public ActionResult Index()
        {
            return View(db.TipoServicio.ToList());
        }

        //
        // GET: /TipoServicio/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoServicio tiposervicio = db.TipoServicio.Find(id);
            if (tiposervicio == null)
            {
                return HttpNotFound();
            }
            return View(tiposervicio);
        }

        //
        // GET: /TipoServicio/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoServicio/Create

        [HttpPost]
        public ActionResult Create(TipoServicio tiposervicio)
        {
            if (ModelState.IsValid)
            {
                db.TipoServicio.Add(tiposervicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposervicio);
        }

        //
        // GET: /TipoServicio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoServicio tiposervicio = db.TipoServicio.Find(id);
            if (tiposervicio == null)
            {
                return HttpNotFound();
            }
            return View(tiposervicio);
        }

        //
        // POST: /TipoServicio/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoServicio tiposervicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposervicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposervicio);
        }

        //
        // GET: /TipoServicio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoServicio tiposervicio = db.TipoServicio.Find(id);
            if (tiposervicio == null)
            {
                return HttpNotFound();
            }
            return View(tiposervicio);
        }

        //
        // POST: /TipoServicio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoServicio tiposervicio = db.TipoServicio.Find(id);
            db.TipoServicio.Remove(tiposervicio);
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