using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using SchoolManagement.DAO;

namespace SchoolManagement.DAL
{
    public class UserInfoDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString);
        public DataSet LoadAllDataDAL()
        {
            SqlCommand com = new SqlCommand("sp_LoadAllData_UserInfo", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }

        public void AddNewInfoDAL(UserDAO aDao)
        {
            SqlCommand com = new SqlCommand("sp_Insert_User", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LoginName", aDao.LoginName);
            com.Parameters.AddWithValue("@UserName", aDao.UserName);
            com.Parameters.AddWithValue("@Password", aDao.Password);
            com.Parameters.AddWithValue("@UserType", aDao.UserType);
            com.Parameters.AddWithValue("@ActiveStatus", aDao.ActiveStatus);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}