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
    public class PymesController : Controller
    {
        private PymesFinder db = new PymesFinder();
        //
        // GET: /Pymes/

        public ActionResult Index()
        {
            var pymes = db.Pymes.Include(p => p.Usuario);
            return View(pymes.ToList());
        }

        //
        // GET: /Pymes/Details/5

        public ActionResult Details(int id = 0)
        {
            Pymes pymes = db.Pymes.Find(id);
            if (pymes == null)
            {
                return HttpNotFound();
            }
            return View(pymes);
        }

        //
        // GET: /Pymes/Create

        public ActionResult Create()
        {
            ViewBag.usuarioID = new SelectList(db.Usuario, "usuarioID", "nombre");
            return View();
        }

        //
        // POST: /Pymes/Create

        [HttpPost]
        public ActionResult Create(Pymes pymes)
        {
            if (ModelState.IsValid)
            {
                db.Pymes.Add(pymes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usuarioID = new SelectList(db.Usuario, "usuarioID", "nombre", pymes.usuarioID);
            return View(pymes);
        }

        //
        // GET: /Pymes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pymes pymes = db.Pymes.Find(id);
            if (pymes == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuarioID = new SelectList(db.Usuario, "usuarioID", "nombre", pymes.usuarioID);
            return View(pymes);
        }

        //
        // POST: /Pymes/Edit/5

        [HttpPost]
        public ActionResult Edit(Pymes pymes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pymes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usuarioID = new SelectList(db.Usuario, "usuarioID", "nombre", pymes.usuarioID);
            return View(pymes);
        }

        //
        // GET: /Pymes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pymes pymes = db.Pymes.Find(id);
            if (pymes == null)
            {
                return HttpNotFound();
            }
            return View(pymes);
        }

        //
        // POST: /Pymes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pymes pymes = db.Pymes.Find(id);
            db.Pymes.Remove(pymes);
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