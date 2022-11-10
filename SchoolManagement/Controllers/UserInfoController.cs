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
    public class UserInfoController : Controller
    {
        UserInfoDAL aDal = new UserInfoDAL();
        // GET: UserInfo
        public ActionResult UserRegistrationList()
        {
            return View();
        }
        public ActionResult UserRegistration()
        {
            return View();
        }

        public JsonResult Save_Info(UserDAO aDao)
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
            List<UserDAO> lists = new List<UserDAO>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new UserDAO
                {
                    UserId = Convert.ToInt32(dr["UserId"]),
                    SL = (dr["SL"].ToString()),
                    UserName = (dr["UserName"].ToString()),
                    LoginName = (dr["LoginName"].ToString()),
                    Password = (dr["Password"].ToString()),
                    UserType = (dr["UserType"].ToString()),
                    ActiveStatus = Convert.ToBoolean(dr["ActiveStatus"].ToString())



                });

            }

            return Json(lists, JsonRequestBehavior.AllowGet);
        }
    }
}