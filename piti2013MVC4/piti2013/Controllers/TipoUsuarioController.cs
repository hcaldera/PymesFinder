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
    public class TipoUsuarioController : Controller
    {
        private PymesFinder db = new PymesFinder();

        //
        // GET: /TipoUsuario/

        public ActionResult Index()
        {
            return View(db.TipoUsuario.ToList());
        }

        //
        // GET: /TipoUsuario/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoUsuario tipousuario = db.TipoUsuario.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        //
        // GET: /TipoUsuario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoUsuario/Create

        [HttpPost]
        public ActionResult Create(TipoUsuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                db.TipoUsuario.Add(tipousuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipousuario);
        }

        //
        // GET: /TipoUsuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoUsuario tipousuario = db.TipoUsuario.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        //
        // POST: /TipoUsuario/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoUsuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipousuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipousuario);
        }

        //
        // GET: /TipoUsuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoUsuario tipousuario = db.TipoUsuario.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        //
        // POST: /TipoUsuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoUsuario tipousuario = db.TipoUsuario.Find(id);
            db.TipoUsuario.Remove(tipousuario);
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