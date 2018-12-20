using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DMSDAL;
using DMSModels.Models;

namespace DMSWeb.Controllers
{
    public class KeywordDataTypesController : Controller
    {
        private DMSDbContext db = new DMSDbContext();

        // GET: KeywordDataTypes
        public ActionResult Index()
        {
            return View(db.KeywordDataTypes.ToList());
        }

        // GET: KeywordDataTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeywordDataType keywordDataType = db.KeywordDataTypes.Find(id);
            if (keywordDataType == null)
            {
                return HttpNotFound();
            }
            return View(keywordDataType);
        }

        // GET: KeywordDataTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KeywordDataTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KeywordDataTypeId,KeywordDataTypeName")] KeywordDataType keywordDataType)
        {
            if (ModelState.IsValid)
            {
                db.KeywordDataTypes.Add(keywordDataType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(keywordDataType);
        }

        // GET: KeywordDataTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeywordDataType keywordDataType = db.KeywordDataTypes.Find(id);
            if (keywordDataType == null)
            {
                return HttpNotFound();
            }
            return View(keywordDataType);
        }

        // POST: KeywordDataTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KeywordDataTypeId,KeywordDataTypeName")] KeywordDataType keywordDataType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(keywordDataType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(keywordDataType);
        }

        // GET: KeywordDataTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeywordDataType keywordDataType = db.KeywordDataTypes.Find(id);
            if (keywordDataType == null)
            {
                return HttpNotFound();
            }
            return View(keywordDataType);
        }

        // POST: KeywordDataTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KeywordDataType keywordDataType = db.KeywordDataTypes.Find(id);
            db.KeywordDataTypes.Remove(keywordDataType);
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
