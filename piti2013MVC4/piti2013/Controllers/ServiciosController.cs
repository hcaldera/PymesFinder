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
    public class ServiciosController : Controller
    {
        private PymesFinder db = new PymesFinder();

        //
        // GET: /Servicios/

        public ActionResult Index()
        {
            var servicios = db.Servicios.Include(s => s.Estatus).Include(s => s.Pymes).Include(s => s.TipoServicio);
            return View(servicios.ToList());
        }

        //
        // GET: /Servicios/Details/5

        public ActionResult Details(int id = 0)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        //
        // GET: /Servicios/Create

        public ActionResult Create()
        {
            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion");
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre");
            ViewBag.tiposervicioID = new SelectList(db.TipoServicio, "tiposervicioID", "descripcion");
            return View();
        }

        //
        // POST: /Servicios/Create

        [HttpPost]
        public ActionResult Create(Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion", servicios.estatusID);
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre", servicios.pymesID);
            ViewBag.tiposervicioID = new SelectList(db.TipoServicio, "tiposervicioID", "descripcion", servicios.tiposervicioID);
            return View(servicios);
        }

        //
        // GET: /Servicios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion", servicios.estatusID);
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre", servicios.pymesID);
            ViewBag.tiposervicioID = new SelectList(db.TipoServicio, "tiposervicioID", "descripcion", servicios.tiposervicioID);
            return View(servicios);
        }

        //
        // POST: /Servicios/Edit/5

        [HttpPost]
        public ActionResult Edit(Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion", servicios.estatusID);
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre", servicios.pymesID);
            ViewBag.tiposervicioID = new SelectList(db.TipoServicio, "tiposervicioID", "descripcion", servicios.tiposervicioID);
            return View(servicios);
        }

        //
        // GET: /Servicios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        //
        // POST: /Servicios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            db.Servicios.Remove(servicios);
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