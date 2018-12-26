using DMSDAL;
using DMSModels.Models;
using DMSModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMSWeb.Controllers
{
    public class DropZoneController : Controller
    {
        private DMSDbContext db = new DMSDbContext();
        // GET: DropZone
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveDropzoneJsUploadedFiles()
        {
            bool isSavedSuccessfully = false;

            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];

                //You can Save the file content here

                isSavedSuccessfully = true;
            }

            return Json(new { Message = string.Empty });

        }

        public ActionResult SaveUploadedFile(IEnumerable<HttpPostedFileBase> files)
        {
            bool SavedSuccessfully = true;
            string fName = "";
            try
            {
                //loop through all the files
                foreach (var file in files)
                {

                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\", Server.MapPath(@"\")));

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                        var fileName1 = Path.GetFileName(file.FileName);

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);

                    }

                }

            }
            catch (Exception ex)
            {
                SavedSuccessfully = false;
            }


            if (SavedSuccessfully)
            {
                return RedirectToAction("Index", new { Message = "All files saved successfully" });
            }
            else
            {
                return RedirectToAction("Index", new { Message = "Error in saving file" });
            }
        }

        public ActionResult Create()
        {
            ViewBag.DocumentType = db.DocumentType.ToList();
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

        [HttpPost]
        public ActionResult PassArray(DocumentType documentType)
        {
            if (documentType.DocumentTypeId != 0)
            {
                var DocumentType = db.DocumentType.Include(cm => cm.Keywords).SingleOrDefault(x => x.DocumentTypeId == documentType.DocumentTypeId);

                var KeyWord = DocumentType.Keywords.ToList();

                var Keywords = new List<AssignedKeyword>();
                foreach (var keyword in KeyWord)
                {
                    Keywords.Add(new AssignedKeyword
                    {
                        //                    KeywordId = keyword.KeywordId,
                        KeywordName = keyword.KeywordName,
                    });
                }

                //return Json(DocumentType, JsonRequestBehavior.DenyGet);
                //Do your processing
                return Json(Keywords);
            }
            else
            {
                var Keywords = new List<AssignedKeyword>();
                return Json(Keywords);
            }
        }
    }
}