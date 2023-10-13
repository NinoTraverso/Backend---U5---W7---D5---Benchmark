using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inforno.Models;

namespace Inforno.Controllers
{
    public class DettaglisController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Dettaglis
        public ActionResult Index()
        {
            var dettagli = db.Dettagli.Include(d => d.Ordini).Include(d => d.Prodotti);
            return View(dettagli.ToList());
        }

        // GET: Dettaglis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dettagli dettagli = db.Dettagli.Find(id);
            if (dettagli == null)
            {
                return HttpNotFound();
            }
            return View(dettagli);
        }

        // GET: Dettaglis/Create
        public ActionResult Create()
        {
            ViewBag.OrdineID = new SelectList(db.Ordini, "IdOrdine", "NomeCliente");
            ViewBag.ProdottoID = new SelectList(db.Prodotti, "IdProdotto", "Nome");
            return View();
        }

        // POST: Dettaglis/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDettaglio,ProdottoID,Quantita,OrdineID")] Dettagli dettagli)
        {
            if (ModelState.IsValid)
            {
                db.Dettagli.Add(dettagli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrdineID = new SelectList(db.Ordini, "IdOrdine", "NomeCliente", dettagli.OrdineID);
            ViewBag.ProdottoID = new SelectList(db.Prodotti, "IdProdotto", "Nome", dettagli.ProdottoID);
            return View(dettagli);
        }

        // GET: Dettaglis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dettagli dettagli = db.Dettagli.Find(id);
            if (dettagli == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrdineID = new SelectList(db.Ordini, "IdOrdine", "NomeCliente", dettagli.OrdineID);
            ViewBag.ProdottoID = new SelectList(db.Prodotti, "IdProdotto", "Nome", dettagli.ProdottoID);
            return View(dettagli);
        }

        // POST: Dettaglis/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDettaglio,ProdottoID,Quantita,OrdineID")] Dettagli dettagli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dettagli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrdineID = new SelectList(db.Ordini, "IdOrdine", "NomeCliente", dettagli.OrdineID);
            ViewBag.ProdottoID = new SelectList(db.Prodotti, "IdProdotto", "Nome", dettagli.ProdottoID);
            return View(dettagli);
        }

        // GET: Dettaglis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dettagli dettagli = db.Dettagli.Find(id);
            if (dettagli == null)
            {
                return HttpNotFound();
            }
            return View(dettagli);
        }

        // POST: Dettaglis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dettagli dettagli = db.Dettagli.Find(id);
            db.Dettagli.Remove(dettagli);
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
