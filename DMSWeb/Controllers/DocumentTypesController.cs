using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DMSDAL;
using DMSModels;
using DMSModels.Models;
using DMSModels.ViewModels;

namespace DMSWeb.Controllers
{
    public class DocumentTypesController : Controller
    {
        private DMSDbContext db = new DMSDbContext();

        // GET: DocumentTypes
        public ActionResult Index()
        {
            return View(db.DocumentType.ToList());
        }

        // GET: DocumentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentType documentType = db.DocumentType.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

       
        // GET: DocumentTypes/Create
        public ActionResult Create()
        {
            var documentType = new DocumentType();
            documentType.Keywords = new List<Keyword>();
            PopulateAssignedKeyword(documentType);

            //ViewBag.Keywords = db.Keyword.ToList();
            return View();
        }


        private void PopulateAssignedKeyword(DocumentType documentType)
        {
            var allKeywords = db.Keyword;
            var documentTypeKeywords = new HashSet<int>(documentType.Keywords.Select(c => c.KeywordId));
            var viewModel = new List<AssignedKeyword>();
            foreach (var keyword in allKeywords)
            {
                viewModel.Add(new AssignedKeyword
                {
                    KeywordId = keyword.KeywordId,
                    KeywordName = keyword.KeywordName,
                    Assigned = documentTypeKeywords.Contains(keyword.KeywordId)
                });
            }
            ViewBag.Keywords = viewModel;
        }

        // POST: DocumentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentType documentType, string[] selectedKeywords)
        {


            if (selectedKeywords != null)
            {
                documentType.Keywords = new List<Keyword>();
                foreach (var keyword in selectedKeywords)
                {
                    var keywordToAdd = db.Keyword.Find(int.Parse(keyword));
                    documentType.Keywords.Add(keywordToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.DocumentType.Add(documentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedKeyword(documentType);
            return View(documentType);

        }

        // GET: DocumentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentType documentType = db.DocumentType.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

        // POST: DocumentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentTypeId,DocumentTypeName")] DocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentType);
        }

        // GET: DocumentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentType documentType = db.DocumentType.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

        // POST: DocumentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentType documentType = db.DocumentType.Find(id);
            db.DocumentType.Remove(documentType);
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
