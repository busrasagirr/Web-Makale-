using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MakaleWeb.Entities;
using MakaleWeb.Models;

namespace MakaleWeb.Controllers
{
    public class YorumlarsController : Controller
    {
        private MakaleWebContext db = new MakaleWebContext();

        // GET: Yorumlars
        public ActionResult Index()
        {
            return View(db.Yorumlars.ToList());
        }

        // GET: Yorumlars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorumlar yorumlar = db.Yorumlars.Find(id);
            if (yorumlar == null)
            {
                return HttpNotFound();
            }
            return View(yorumlar);
        }

        // GET: Yorumlars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yorumlars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Metin,OlusturmaTarihi,DegistirmeTarihi,DegistirenKullanici")] Yorumlar yorumlar)
        {
            if (ModelState.IsValid)
            {
                db.Yorumlars.Add(yorumlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yorumlar);
        }

        // GET: Yorumlars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorumlar yorumlar = db.Yorumlars.Find(id);
            if (yorumlar == null)
            {
                return HttpNotFound();
            }
            return View(yorumlar);
        }

        // POST: Yorumlars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Metin,OlusturmaTarihi,DegistirmeTarihi,DegistirenKullanici")] Yorumlar yorumlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorumlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yorumlar);
        }

        // GET: Yorumlars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorumlar yorumlar = db.Yorumlars.Find(id);
            if (yorumlar == null)
            {
                return HttpNotFound();
            }
            return View(yorumlar);
        }

        // POST: Yorumlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yorumlar yorumlar = db.Yorumlars.Find(id);
            db.Yorumlars.Remove(yorumlar);
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
