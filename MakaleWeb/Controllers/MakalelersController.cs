using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MakaleWeb.Entities;
using MakaleWeb.BusinessLayer;

namespace MakaleWeb.Controllers
{
    public class MakalelersController : Controller
    {
        private MakaleYonet makaleyonet = new MakaleYonet();
        private Kullanicilar user;
        // GET: Makalelers
        public ActionResult Index()
        {

            if (Session["login"] != null)
            {
                user = Session["login"] as Kullanicilar;
            }
            return View(makaleyonet.ListQueryable().Where(x => x.Kullanici.ID == user.ID).OrderByDescending(x => x.DegistirmeTarihi).ToList());
        }

        // GET: Makalelers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //Makaleler makaleler = db.Makalelers.Find(id);
        //    //if (makaleler == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(makaleler);
        //}

        // GET: Makalelers/Create
        public ActionResult Create()
        {
            //ViewBag.KategorilerID = new SelectList(db.Kategorilers, "ID", "Baslik");
            return View();
        }

        // POST: Makalelers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Baslik,Metin,Taslakmi,BegeniSayisi,KategorilerID,OlusturmaTarihi,DegistirmeTarihi,DegistirenKullanici")] Makaleler makaleler)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Makalelers.Add(makaleler);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.KategorilerID = new SelectList(db.Kategorilers, "ID", "Baslik", makaleler.KategorilerID);
            return View(makaleler);
        }

        // GET: Makalelers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //Makaleler makaleler = db.Makalelers.Find(id);
        //    //if (makaleler == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //ViewBag.KategorilerID = new SelectList(db.Kategorilers, "ID", "Baslik", makaleler.KategorilerID);
        //    return View(makaleler);
        //}

        //// POST: Makalelers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Baslik,Metin,Taslakmi,BegeniSayisi,KategorilerID,OlusturmaTarihi,DegistirmeTarihi,DegistirenKullanici")] Makaleler makaleler)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    db.Entry(makaleler).State = EntityState.Modified;
        //    //    db.SaveChanges();
        //    //    return RedirectToAction("Index");
        //    //}
        //    //ViewBag.KategorilerID = new SelectList(db.Kategorilers, "ID", "Baslik", makaleler.KategorilerID);
        //    //return View(makaleler);
        //}

        // GET: Makalelers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Makaleler makaleler = db.Makalelers.Find(id);
        //    if (makaleler == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(makaleler);
        //}

        //// POST: Makalelers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Makaleler makaleler = db.Makalelers.Find(id);
        //    db.Makalelers.Remove(makaleler);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
