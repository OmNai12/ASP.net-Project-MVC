using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolManagement.DAL
{
    public class StudentProfileDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString);

        public DataTable GetStudentInfoDAL(string prm)
        {
            SqlCommand com = new SqlCommand("sp_GET_StudentInfoByStuId", conn);
            
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@prm", prm);

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dss = new DataTable();

            da.Fill(dss);

            return dss;

        }
    }
}