using System;
using DOANno1.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANno1.Controllers
{
    public class ChartController : Controller
    {
        //public DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult GetAttendanceData(int year)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var data = (from cc in db.QLChamCongs
                            where cc.NamCC == year
                            group cc by cc.ThangCC into g
                            select new
                            {
                                ThangCC = g.Key,
                                SoLuongNhanVien = g.Count()
                            }).OrderBy(x => x.ThangCC).ToList();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetYears()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var years = db.QLChamCongs.Select(c => c.NamCC).Distinct().ToList();
            return Json(years, JsonRequestBehavior.AllowGet);
        }
    }
}