using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISAPI.Models
{
    public class Teacher
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string school { get; set; }
        public string id_number { get; set; }
        public string code { get; set; }
        public bool coop { get; set; }
    }
}