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
    public class TrimesterInfoDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString);

        public void AddNewInfoDAL(TrimesterDAO aDao)
        {
            SqlCommand com = new SqlCommand("sp_Insert_TrimesterInfo", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TrimesterInfoName", aDao.TrimesterInfoName);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }

        public DataSet LoadAllDataDAL()
        {
            SqlCommand com = new SqlCommand("sp_LoadAllData_Trimester", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }
    }
}