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
    public class StudentMarkController : Controller
    {
        StudentMarksEntryDAL aDal = new StudentMarksEntryDAL();
        // GET: StudentMark
        public ActionResult StudentMarksEntry()
        {
            return View();
        }

        public ActionResult StudentMarksList()
        {
            return View();
        }

        public ActionResult Save_Info(StudentMarksEntryDAO ADao)
        {
            string Mes = "";

            try

            {
                aDal.AddNewInfoDAL(ADao);

                Mes = "Operation Success!!";
            }
            catch (Exception ex)

            {
                Mes = "Error";
            }
            return Json(Mes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudentMarksList(string prm)

        {
            DataTable dr = aDal.GetStudentMarksListDAL(prm);

            string jJSONresult;

            jJSONresult = JsonConvert.SerializeObject(dr);


            return Json(jJSONresult, JsonRequestBehavior.AllowGet);
        }
    }
}