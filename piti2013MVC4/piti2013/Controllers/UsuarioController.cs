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
    public class UsuarioController : Controller
    {
        private PymesFinder db = new PymesFinder();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Estatus).Include(u => u.TipoUsuario);
            return View(usuario.ToList());
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion");
            ViewBag.tipousuarioID = new SelectList(db.TipoUsuario, "tipousuarioID", "descripcion");
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion", usuario.estatusID);
            ViewBag.tipousuarioID = new SelectList(db.TipoUsuario, "tipousuarioID", "descripcion", usuario.tipousuarioID);
            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion", usuario.estatusID);
            ViewBag.tipousuarioID = new SelectList(db.TipoUsuario, "tipousuarioID", "descripcion", usuario.tipousuarioID);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estatusID = new SelectList(db.Estatus, "estatusID", "descripcion", usuario.estatusID);
            ViewBag.tipousuarioID = new SelectList(db.TipoUsuario, "tipousuarioID", "descripcion", usuario.tipousuarioID);
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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