using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.DAL;
using SchoolManagement.DAO;
using Newtonsoft.Json;

namespace SchoolManagement.Controllers
{
    public class StudentCourseOfferController : Controller
    {
        StudentCourseOfferDAL aDal = new StudentCourseOfferDAL();
        // GET: StudentCourseOffer
        public ActionResult StudentCourseOfferList()
        {
            return View();
        }
        public ActionResult StudentCourseOfferEntry()
        {
            return View();
        }

        public ActionResult GetStudentCourseOfferList(string prm)
        {
            DataTable dr = aDal.GetStudentCourseOfferListDAL(prm);
            string jJSONresult;
            jJSONresult = JsonConvert.SerializeObject(dr);
            return Json(jJSONresult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ddlLoadStudentIdName()
        {
            DataSet ds = aDal.BatchDDLLoadDAL();
            List<StudentDAO> lists = new List<StudentDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new StudentDAO
                {
                    StudentId = Convert.ToInt32(dr["StudentId"]),
                    StudentIdNO = (dr["StudentIdNO"].ToString())
                });
            }
            return Json(lists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ddlLoadTrimesterInfo()
        {
            DataSet ds = aDal.TrimesterDDLLoadDAL();
            List<TrimesterDAO> lists = new List<TrimesterDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new TrimesterDAO
                {
                    TrimesterInfoId = Convert.ToInt32(dr["TrimesterInfoId"]),

                    TrimesterInfoName = (dr["TrimesterInfoName"].ToString())
                });
            }
            return Json(lists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ddlLoadCourseInfo()
        {

            DataSet ds = aDal.CourseDDLLoadDAL();
            List<CourseDAO> lists = new List<CourseDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new CourseDAO
                {
                    CourseId = Convert.ToInt32(dr["CourseId"]),

                    CourseName = (dr["CourseName"].ToString())


                });

            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save_Info(StudentCourseOfferDAO ADao)
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

    }
}