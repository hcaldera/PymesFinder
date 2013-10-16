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
    public class PublicidadController : Controller
    {
        private PymesFinder db = new PymesFinder();

        //
        // GET: /Publicidad/

        public ActionResult Index()
        {
            var publicidad = db.Publicidad.Include(p => p.Pymes).Include(p => p.TipoPublicidad);
            return View(publicidad.ToList());
        }

        //
        // GET: /Publicidad/Details/5

        public ActionResult Details(int id = 0)
        {
            Publicidad publicidad = db.Publicidad.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            return View(publicidad);
        }

        //
        // GET: /Publicidad/Create

        public ActionResult Create()
        {
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre");
            ViewBag.tipopublicidadID = new SelectList(db.TipoPublicidad, "tipopublicidadID", "descripcion");
            return View();
        }

        //
        // POST: /Publicidad/Create

        [HttpPost]
        public ActionResult Create(Publicidad publicidad)
        {
            if (ModelState.IsValid)
            {
                db.Publicidad.Add(publicidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre", publicidad.pymesID);
            ViewBag.tipopublicidadID = new SelectList(db.TipoPublicidad, "tipopublicidadID", "descripcion", publicidad.tipopublicidadID);
            return View(publicidad);
        }

        //
        // GET: /Publicidad/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Publicidad publicidad = db.Publicidad.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre", publicidad.pymesID);
            ViewBag.tipopublicidadID = new SelectList(db.TipoPublicidad, "tipopublicidadID", "descripcion", publicidad.tipopublicidadID);
            return View(publicidad);
        }

        //
        // POST: /Publicidad/Edit/5

        [HttpPost]
        public ActionResult Edit(Publicidad publicidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre", publicidad.pymesID);
            ViewBag.tipopublicidadID = new SelectList(db.TipoPublicidad, "tipopublicidadID", "descripcion", publicidad.tipopublicidadID);
            return View(publicidad);
        }

        //
        // GET: /Publicidad/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Publicidad publicidad = db.Publicidad.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            return View(publicidad);
        }

        //
        // POST: /Publicidad/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicidad publicidad = db.Publicidad.Find(id);
            db.Publicidad.Remove(publicidad);
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