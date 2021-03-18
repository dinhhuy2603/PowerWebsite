using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerWebsite.Models
{
    public class Result
    {
        [Key]
        public int Thoigian { get; set; }
        public int Thang { get; set; }
        public string firstValue { get; set; }
        public string lastValue { get; set; }
    }
}