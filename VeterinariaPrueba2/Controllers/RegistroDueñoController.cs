using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaPrueba2.Models;

namespace VeterinariaPrueba2.Controllers
{
    public class RegistroDueñoController : Controller
    {
        private VeterinariaDBContext db = new VeterinariaDBContext();

        // GET: RegistroDueño
        public ActionResult Index()
        {
            var dueños = db.Dueños.Include(r => r.tblRegistroPersonal);
            return View(dueños.ToList());
        }

        // GET: RegistroDueño/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                   //linea 1
            RegistroDueño registroDueño = db.Dueños.Where(e => e.Id == id).Include(d => d.tblRegistroPersonal).FirstOrDefault();
            if (registroDueño == null)
            {
                return HttpNotFound();
            }
            return View(registroDueño);
        }

        // GET: RegistroDueño/Create
        public ActionResult Create()
        {
            // linea 2
                        //en esta instruccion seleccionamos la base de 
                        //datos y la tabla a la que vamos a solicitar mi ID y mi
                        //atributo(probar con el nombre de la base de 
                        //datos en sql o  con las tablas )
            ViewBag.tblRegistroPersonalId = new SelectList(db.Personal, "Id", "Especialidad");
            
            return View();
        }

        // POST: RegistroDueño/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
                //agregando al bind en create
        public ActionResult Create([Bind(Include = "Id,tblRegistroPersonalId,Nombre,Calle,Ciudad,Telefono")] RegistroDueño registroDueño)
        {
            if (ModelState.IsValid)
            {
                db.Dueños.Add(registroDueño);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                //linea 3
            ViewBag.tblRegistroPersonalId = new SelectList(db.Personal, "Id", "especialidad", registroDueño.tblRegistroPersonalId);
            return View(registroDueño);
        }

        // GET: RegistroDueño/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDueño registroDueño = db.Dueños.Find(id);
            if (registroDueño == null)
            {
                return HttpNotFound();
            }
                //linea 1 en edit
            ViewBag.tblRegistroPersonalId = new SelectList(db.Personal, "Id", "Especialidad", registroDueño.tblRegistroPersonalId);
            return View(registroDueño);
        }

        // POST: RegistroDueño/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
             //agregando al bind en edit
        public ActionResult Edit([Bind(Include = "Id,tblRegistroPersonalId,Nombre,Calle,Ciudad,Telefono")] RegistroDueño registroDueño)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroDueño).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                //linea 2 en edit
            ViewBag.tblRegistroPersonalId = new SelectList(db.Personal, "Id", "Especialidad", registroDueño.tblRegistroPersonalId);
            return View(registroDueño);
        }

        // GET: RegistroDueño/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDueño registroDueño = db.Dueños.Find(id);
            if (registroDueño == null)
            {
                return HttpNotFound();
            }
            return View(registroDueño);
        }

        // POST: RegistroDueño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroDueño registroDueño = db.Dueños.Find(id);
            db.Dueños.Remove(registroDueño);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
