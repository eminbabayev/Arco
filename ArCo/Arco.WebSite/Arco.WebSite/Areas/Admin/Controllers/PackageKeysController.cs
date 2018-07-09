using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Arco.WebSite.Models;

namespace Arco.WebSite.Areas.Admin.Controllers
{
    public class PackageKeysController : Controller
    {
        private ArcoEntities db = new ArcoEntities();

        // GET: Admin/PackageKeys
        public ActionResult Index()
        {
            var packageKeys = db.PackageKeys.Include(p => p.Package);
            return View(packageKeys.ToList());
        }

        // GET: Admin/PackageKeys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageKey packageKey = db.PackageKeys.Find(id);
            if (packageKey == null)
            {
                return HttpNotFound();
            }
            return View(packageKey);
        }

        // GET: Admin/PackageKeys/Create
        public ActionResult Create()
        {
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name");
            return View();
        }

        // POST: Admin/PackageKeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PackageId,Name,IsOk")] PackageKey packageKey)
        {
            if (ModelState.IsValid)
            {
                db.PackageKeys.Add(packageKey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", packageKey.PackageId);
            return View(packageKey);
        }

        // GET: Admin/PackageKeys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageKey packageKey = db.PackageKeys.Find(id);
            if (packageKey == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", packageKey.PackageId);
            return View(packageKey);
        }

        // POST: Admin/PackageKeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PackageId,Name,IsOk")] PackageKey packageKey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packageKey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", packageKey.PackageId);
            return View(packageKey);
        }

        // GET: Admin/PackageKeys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageKey packageKey = db.PackageKeys.Find(id);
            if (packageKey == null)
            {
                return HttpNotFound();
            }
            return View(packageKey);
        }

        // POST: Admin/PackageKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PackageKey packageKey = db.PackageKeys.Find(id);
            db.PackageKeys.Remove(packageKey);
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
