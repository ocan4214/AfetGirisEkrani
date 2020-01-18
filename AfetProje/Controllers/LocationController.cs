using AfetProje.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AfetProje.Controllers
{
    public class LocationController : Controller
    {
        private AfetContext db=new AfetContext();

        public void bindProvince()
        {
            var Provinces = db.iller.ToList();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "--Select Province--", Value = "0" });

            foreach (var m in Provinces)
            {
                li.Add(new SelectListItem { Text = m.IL_ADI, Value = m.IL_ID.ToString() });
                ViewBag.state = li;
            }

        }

        public JsonResult getIlce(int id)
        {
            var ddlIlce = db.ilceler.Where(x => x.IL_ID == id).ToList();
            List<SelectListItem> liilceler = new List<SelectListItem>();

            liilceler.Add(new SelectListItem { Text = "--Select Borough--", Value = "0" });
            if(ddlIlce!=null)
            {
                foreach(var x in ddlIlce)
                {
                    liilceler.Add(new SelectListItem { Text = x.ILCE_ADI, Value = x.ILCE_ID.ToString() });
                }
            }

            return Json(new SelectList(liilceler, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

    }
}