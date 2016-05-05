using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISAPI.Models
{
    public class School
    {
        public string id { get; set; }
        public string domain {get; set;}
        public string email {get; set;}
        public string name {get; set;}
        public string street_address {get; set;}
        public string city {get; set;}
        public string postal_code {get; set;}
        public string phone {get; set;}
        public string maps_url {get; set;}
        public string panel {get; set;}
        public bool school_day {get; set;}
    }
}