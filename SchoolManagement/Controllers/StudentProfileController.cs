using SchoolManagement.DAL;
using SchoolManagement.DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class StudentProfileController : Controller
    {
        StudentProfileDAL aDal = new StudentProfileDAL();
        // GET: StudentProfile
        public ActionResult Marks()
        {
            return View();
        }

        public ActionResult GetStudentInfo()
        {
            string prm = Session["StuId"].ToString();
            DataTable dr = aDal.GetStudentInfoDAL(prm);
            string jJSONresult;
            jJSONresult = JsonConvert.SerializeObject(dr);
            return Json(jJSONresult, JsonRequestBehavior.AllowGet);
        }
    }
}