using SchoolManagement.DAL;
using SchoolManagement.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class TrimesterInfoController : Controller
    {
        TrimesterInfoDAL aDal = new TrimesterInfoDAL();
        // GET: TrimesterInfo
        public ActionResult TrimesterList()
        {
            return View();
        }

        public ActionResult TrimesterEntry()
        {
            return View();
        }

        public JsonResult Save_Info(TrimesterDAO aDao)
        {
            string Mes = "";
            try
            {
                aDal.AddNewInfoDAL(aDao);
                Mes = "Operation Successful!!";
            }
            catch (Exception e)
            {
                Mes = "Operation Faild!!";
            }
            return Json(Mes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadData()
        {
            DataSet ds = aDal.LoadAllDataDAL();
            List<TrimesterDAO> lists = new List<TrimesterDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new TrimesterDAO
                {
                    TrimesterInfoId = Convert.ToInt32(dr["TrimesterInfoId"]),
                    SL = (dr["SL"].ToString()),
                    TrimesterInfoName = (dr["TrimesterInfoName"].ToString())
                });
            }
            return Json(lists, JsonRequestBehavior.AllowGet);
        }
    }
}