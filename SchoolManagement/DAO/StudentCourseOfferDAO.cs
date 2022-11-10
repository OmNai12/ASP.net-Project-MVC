using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.DAO
{
    public class StudentCourseOfferDAO
    {
        public int StudentCourseOfferId { get; set; }
        public string CourseId { get; set; }
        public int TrimesterInfoId { get; set; }
        public int StudentId { get; set; }
        public DateTime CourseOfferDate { get; set; }
    }
}