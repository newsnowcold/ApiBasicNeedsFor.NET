using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class TestModel
    {
        public string Param1 { get; set; }
        public int Param2 { get; set; }
        public bool Param3 { get; set; }
        public List<SampleListItem> Param4 { get; set; }
    }

    public class SampleListItem
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }
}