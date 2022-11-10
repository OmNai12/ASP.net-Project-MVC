using SchoolManagement.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SchoolManagement.DAL
{
    public class StudentMarksEntryDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString);
        public void AddNewInfoDAL(StudentMarksEntryDAO aDao)
        {

            foreach (var item in aDao.StudentMarksEntryDAOLists)
            {
                SqlCommand com = new SqlCommand("sp_Insert_StudentMarksEntry_Info", conn);

                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@StudentId", item.StudentId);

                com.Parameters.AddWithValue("@TrimesterInfoId", item.TrimesterInfoId);

                com.Parameters.AddWithValue("@CourseId", item.CourseId);

                com.Parameters.AddWithValue("@Marks", item.Marks);

                com.Parameters.AddWithValue("@MarksOutOf", item.MarksOutOf);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
            }

        }

        public DataTable GetStudentMarksListDAL(string prm)

        {
            SqlCommand com = new SqlCommand("sp_StudentMarksListLoadByParm", conn);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@prm", prm);

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dss = new DataTable();

            da.Fill(dss);

            return dss;

        }
    }
}