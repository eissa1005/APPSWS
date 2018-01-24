using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPSWS.DAL
{
    public class Users
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
    }
}