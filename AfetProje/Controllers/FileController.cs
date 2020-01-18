using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AfetProje.Models;
using AfetProje.DAL;
using System.Data;

namespace AfetProje.Controllers
{
    public class FileController : Controller
    {

        private AfetContext db = new AfetContext();
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }

        [HttpPost]
        public ActionResult DeleteFile(int id)
        {
            bool result = false;
            
             File file = db.Files.Find(id);
            if(file !=null)
            { 
            db.Files.Remove(file);
             db.SaveChanges();
             result = true;
            }


            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }

}