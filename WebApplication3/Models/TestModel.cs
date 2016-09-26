using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class TestModel
    {
        [EmailAddress]
        public string Param1 { get; set; }

        [Phone]
        public int Param2 { get; set; }
        
        public bool Param3 { get; set; }

        [Required]
        public List<SampleListItem> Param4 { get; set; }
    }

    public class SampleListItem
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }
}