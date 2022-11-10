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
    public class StudentCourseOfferDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString);


        public DataSet BatchDDLLoadDAL()
        {
            SqlCommand com = new SqlCommand("sp_StudentIdWithNameDDLLoad", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }

        public DataSet TrimesterDDLLoadDAL()
        {
            SqlCommand com = new SqlCommand("sp_TrimesterDDLLoad", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }

        public DataSet CourseDDLLoadDAL()
        {
            SqlCommand com = new SqlCommand("sp_CourseDDLLoad", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }

        public void AddNewInfoDAL(StudentCourseOfferDAO aDao)
        {
            int[] ids = aDao.CourseId.Split(',').Select(int.Parse).ToArray();
            for (int i = 0; i < ids.Length; i++)
            {
                int aId = ids[i];
                SqlCommand com = new SqlCommand("sp_Insert_StudentCourseOffer_Info", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@StudentId", aDao.StudentId);
                com.Parameters.AddWithValue("@TrimesterInfoId", aDao.TrimesterInfoId);
                com.Parameters.AddWithValue("@CourseOfferDate", aDao.CourseOfferDate);
                com.Parameters.AddWithValue("@CourseId", aId);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
            }
        }

        public DataTable GetStudentCourseOfferListDAL(string prm)
        {
            SqlCommand com = new SqlCommand("sp_StudentCourseOfferListLoadByParm", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@prm", prm);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dss = new DataTable();
            da.Fill(dss);
            return dss;
        }
    }
}