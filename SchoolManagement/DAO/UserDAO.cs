using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.DAO
{
    public class UserDAO
    {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string SL { get; set; }
            public string LoginName { get; set; }
            public string Password { get; set; }
            public string UserType { get; set; }
            public int StudentId { get; set; }
            public bool ActiveStatus { get; set; }
    }
}