using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class FileController : Controller
    {
        private readonly Model_Container db = new Model_Container();
        // GET: File
        ~FileController() 
        {
            db.Dispose();
        }
        public ActionResult Index(int id)
        {
            var uploadedFile = db.UploadedPosters.Find(id);
            return File(uploadedFile.Content, uploadedFile.ContentType);
        }
        public ActionResult Delete(int id)
        {
            var uploadedFile = db.UploadedPosters.Find(id);
            db.UploadedPosters.Remove(uploadedFile);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsolutePath); // refresh caller
        }
    }
}