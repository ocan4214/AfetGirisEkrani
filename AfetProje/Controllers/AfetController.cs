using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AfetProje.DAL;
using AfetProje.Models;

namespace AfetProje.Controllers
{


    public class AfetController : Controller
    {
        private AfetContext db = new AfetContext();
        private static Random random = new Random();
        private static string IDGenerator(int length = 13)
        {
            var pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder GeneratedStream = new StringBuilder();


            for (int i = 0; i < length; i++)
            {
                if (i == 8)
                {
                    GeneratedStream.Append("-");
                }
                else
                {
                    GeneratedStream.Append(pool[random.Next(pool.Length)]);
                }
            }

            return GeneratedStream.ToString();
        }



        public void bindProvince()
        {
            var Provinces = db.iller.ToList();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "--Select Province--", Value = "0" });

            foreach (var m in Provinces)
            {
                li.Add(new SelectListItem { Text = m.IL_ADI, Value = m.IL_ID.ToString() });
                ViewBag.Province = li;

            }

        }
        [HttpPost]
        public JsonResult getIlce(int id)
        {

            var ddlIlce = db.ilceler.Where(x => x.IL_ID == id).ToList();
            List<SelectListItem> liilceler = new List<SelectListItem>();

            liilceler.Add(new SelectListItem { Text = "--Select Borough--", Value = "0" });
            if (ddlIlce != null)
            {
                foreach (var x in ddlIlce)
                {
                    liilceler.Add(new SelectListItem { Text = x.ILCE_ADI, Value = x.ILCE_ID.ToString() });
                }
            }


            return Json(new SelectList(liilceler, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult getIlName(int id)
        {
            var AfetPro = db.Afets.Find(id);
            var Proname = db.iller.Find(Int64.Parse(AfetPro.Province));




            return Json(Proname, JsonRequestBehavior.AllowGet);
        }




        // GET: Afet
        public ActionResult Index()
        {

            return View(db.Afets.ToList());
        }

        // GET: Afet/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Afet afet = db.Afets.Include(s => s.Files).SingleOrDefault(s => s.ID == id);
            il pro = db.iller.Find(Int32.Parse(afet.Province));

            ViewBag.AfetName = pro.IL_ADI;
            if (afet == null)
            {
                return HttpNotFound();
            }
            return View(afet);
        }



        // GET: Afet/Create
        public ActionResult Create()
        {
            bindProvince();
            //TODO
            //DATABASE ID'LERİ SORGULA VE BU ID'LERDEN FARKLI BİR ID OLUŞTURUP VIEW'E YOLLA
            Afet test = new Afet();
            string demoID;
            var result = true;

            do
            {
                demoID = IDGenerator();
                result = db.Afets.Any(a => a.ID == demoID);
            } while (result);

            test.ID = demoID;
            test.GlideNo = demoID;

            return View(test);
        }

        // POST: Afet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GlideNo,FirstSeen,LastSeen,DaysLast,DisasterType,Province,Borough,Village,Neighborhood,BeldeMevki,ReasonofDisaster,Latitude,Longitude,ReasonDetails,EffectedAreas,Source,Status")] Afet afet, HttpPostedFileBase[] upload)
        {
            if (ModelState.IsValid)
            {
                afet.Files = new List<File>();
                foreach (HttpPostedFileBase file in upload)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var Uploadedfile = new File
                        {
                            FileName = System.IO.Path.GetFileName(file.FileName),
                            FileType = FileType.Image,
                            ContentType = file.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(file.InputStream))
                        {
                            Uploadedfile.Content = reader.ReadBytes(file.ContentLength);
                        }
                        afet.Files.Add(Uploadedfile);
                    }
                }

                db.Afets.Add(afet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(afet);
        }

        // GET: Afet/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bindProvince();
            Afet afet = db.Afets.Find(id);

            if (afet == null)
            {
                return HttpNotFound();
            }
            return View(afet);
        }

        // POST: Afet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(string id, HttpPostedFileBase[] upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var afetToUpdate = db.Afets.Find(id);

            if (TryUpdateModel(afetToUpdate, "",
                new string[] { "FirstSeen", "LastSeen", "DaysLast", "DisasterType", "Province", "Borough", "Village", "Neigborhood", "BeldeMevki", "ReasonofDisaster", "Latitude", "Longitude", "ReasonDetails", "EffectedAreas", "Source" }))
            {
                try
                {
                    Afet afet = db.Afets.Find(id);
                    afet.Files = new List<File>();
                    foreach (HttpPostedFileBase file in upload)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            var Uploadedfile = new File
                            {
                                FileName = System.IO.Path.GetFileName(file.FileName),
                                FileType = FileType.Image,
                                ContentType = file.ContentType
                            };
                            using (var reader = new System.IO.BinaryReader(file.InputStream))
                            {
                                Uploadedfile.Content = reader.ReadBytes(file.ContentLength);
                            }
                            afet.Files.Add(Uploadedfile);
                        }
                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException dex)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }


            return View(afetToUpdate);

        }

        // GET: Afet/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afet afet = db.Afets.Find(id);
            if (afet == null)
            {
                return HttpNotFound();
            }
            return View(afet);
        }

        // POST: Afet/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Afet afet = db.Afets.Find(id);
            var files = from file in db.Files
                        where file.Afet.ID == afet.ID
                        select file;

            foreach (var f in files)
            {

                System.Diagnostics.Debug.WriteLine(" 123 " + f);
                db.Files.Remove(f);
            }

            db.Afets.Remove(afet);
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
