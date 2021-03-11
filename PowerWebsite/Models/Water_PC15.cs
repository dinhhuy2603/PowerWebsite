using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PowerWebsite.Models
{
    [Table("hienthi1_water_pc15")]
    public class Water_PC15
    {
        [Key]
        public int idwater { get; set; }
        public string luu_luong_hien_tai { get; set; }
        public string luu_luong_tong { get; set; }
        public int status { get; set; }
    }
    public class WaterPC15View
    {
        [Key]
        public int idwater { get; set; }
        public string luu_luong_hien_tai { get; set; }
        public string luu_luong_tong { get; set; }
        public int status { get; set; }
        public string luu_luong_tong_ngay { get; set; }
    }
}