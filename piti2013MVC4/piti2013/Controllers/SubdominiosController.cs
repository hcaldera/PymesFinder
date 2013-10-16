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
    public class SubdominiosController : Controller
    {
        private PymesFinder db = new PymesFinder();

        //
        // GET: /Subdominios/

        public ActionResult Index()
        {
            var subdominios = db.Subdominios.Include(s => s.Estatus).Include(s => s.Pymes);
            return View(subdominios.ToList());
        }

        //
        // GET: /Subdominios/Details/5

        public ActionResult Details(int id = 0)
        {
            Subdominios subdominios = db.Subdominios.Find(id);
            if (subdominios == null)
            {
                return HttpNotFound();
            }
            return View(subdominios);
        }

        //
        // GET: /Subdominios/Create

        public ActionResult Create()
        {
            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion");
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre");
            return View();
        }

        //
        // POST: /Subdominios/Create

        [HttpPost]
        public ActionResult Create(Subdominios subdominios)
        {
            if (ModelState.IsValid)
            {
                db.Subdominios.Add(subdominios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion", subdominios.estatusID);
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre", subdominios.pymesID);
            return View(subdominios);
        }

        //
        // GET: /Subdominios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Subdominios subdominios = db.Subdominios.Find(id);
            if (subdominios == null)
            {
                return HttpNotFound();
            }
            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion", subdominios.estatusID);
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre", subdominios.pymesID);
            return View(subdominios);
        }

        //
        // POST: /Subdominios/Edit/5

        [HttpPost]
        public ActionResult Edit(Subdominios subdominios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subdominios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion", subdominios.estatusID);
            ViewBag.pymesID = new SelectList(db.Pymes, "pymesID", "nombre", subdominios.pymesID);
            return View(subdominios);
        }

        //
        // GET: /Subdominios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Subdominios subdominios = db.Subdominios.Find(id);
            if (subdominios == null)
            {
                return HttpNotFound();
            }
            return View(subdominios);
        }

        //
        // POST: /Subdominios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Subdominios subdominios = db.Subdominios.Find(id);
            db.Subdominios.Remove(subdominios);
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