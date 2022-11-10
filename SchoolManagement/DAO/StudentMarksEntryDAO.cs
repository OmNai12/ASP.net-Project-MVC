using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.DAO
{
    public class StudentMarksEntryDAO

    {
        public int FakeId { get; set; }

        public List<StudentMarksEntryDAOList> StudentMarksEntryDAOLists { get; set; }

    }

    public class StudentMarksEntryDAOList

    {

        public int StudentMarksEntryId { get; set; }

        public int CourseId { get; set; }

        public int TrimesterInfoId { get; set; }

        public int StudentId { get; set; }

        public decimal Marks { get; set; }

        public decimal MarksOutOf { get; set; }

    }
}