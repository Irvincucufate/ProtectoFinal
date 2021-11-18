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
    public class RegistroAnimalesController : Controller
    {
        private VeterinariaDBContext db = new VeterinariaDBContext();

        // GET: RegistroAnimales
        public ActionResult Index()
        {
            var animales = db.Animales.Include(r => r.tblRegistroDueño);
            return View(animales.ToList());
        }

        // GET: RegistroAnimales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                //linea 1
            RegistroAnimales registroAnimales = db.Animales.Where(e => e.Id == id).Include(d => d.tblRegistroPersonal).Include(d => d.tblRegistroDueño).FirstOrDefault();
            if (registroAnimales == null)
            {
                return HttpNotFound();
            }
            return View(registroAnimales);
        }

        // GET: RegistroAnimales/Create
        public ActionResult Create()
        {
                   //linea 2
            ViewBag.tblRegistroDueñoId = new SelectList(db.Dueños, "Id", "Nombre");
            return View();
        }

        // POST: RegistroAnimales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
                //agregando al bind create
        public ActionResult Create([Bind(Include = "Id,tblRegistroDueñoId,ClaseAnimal,Raza,Edad,Color,Estatura,FechaCita")] RegistroAnimales registroAnimales)
        {
            if (ModelState.IsValid)
            {
                db.Animales.Add(registroAnimales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                                          //linea 3
            ViewBag.tblRegistroDueñoId = new SelectList(db.Dueños, "Id", "Nombre", registroAnimales.tblRegistroDueñoId);
            return View(registroAnimales);
        }

        // GET: RegistroAnimales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAnimales registroAnimales = db.Animales.Find(id);
            if (registroAnimales == null)
            {
                return HttpNotFound();
            }
                //linea 1 en edit
            ViewBag.tblRegistroDueñoId = new SelectList(db.Dueños, "Id", "Nombre", registroAnimales.tblRegistroDueñoId);
            return View(registroAnimales);
        }

        // POST: RegistroAnimales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
                //agregando al bind en edit
        public ActionResult Edit([Bind(Include = "Id,tblRegistroDueñoId,ClaseAnimal,Raza,Edad,Color,Estatura,FechaCita")] RegistroAnimales registroAnimales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroAnimales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                    
            //linea 2 en edit
            ViewBag.tblRegistroDueñoId = new SelectList(db.Dueños, "Id", "Nombre", registroAnimales.tblRegistroDueñoId);
            return View(registroAnimales);
        }

        // GET: RegistroAnimales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAnimales registroAnimales = db.Animales.Find(id);
            if (registroAnimales == null)
            {
                return HttpNotFound();
            }
            return View(registroAnimales);
        }

        // POST: RegistroAnimales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroAnimales registroAnimales = db.Animales.Find(id);
            db.Animales.Remove(registroAnimales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*public ActionResult Salario(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var registro = db.Registro.Where(e => e.Id == id).Include(e => e.tblDatosHorarios).Include(e => e.tblEmpleados).FirstOrDefault();

            return View(salarioEmpleadito);
        } */

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
