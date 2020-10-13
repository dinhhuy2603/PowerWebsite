using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PowerWebsite.Models
{
    [Table("water")]
    public class Water
    {
        [Key]
        public int idwater { get; set; }
        public string luu_luong_hien_tai { get; set; }
        public string luu_luong_tong { get; set; }
        public int status { get; set; }
    }
    public class WaterView
    {
        [Key]
        public int idwater { get; set; }
        public string luu_luong_hien_tai { get; set; }
        public string luu_luong_tong { get; set; }
        public int status { get; set; }
        public string luu_luong_tong_ngay { get; set; }
    }
}