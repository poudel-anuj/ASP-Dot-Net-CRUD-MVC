using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Department.Models
{
    public class tblDepartment
    {
        public int id { get; set; }
        public string departName { get; set; }
        public DateTime entrydate { get; set; }
        public bool status { get; set; }
    }
}