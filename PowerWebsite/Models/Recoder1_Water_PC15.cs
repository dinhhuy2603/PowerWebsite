using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PowerWebsite.Models
{
    [Table("recoder1_water_pc15")]
    public class Recoder1_Water_PC15
    {
        [Key]
        public DateTime Thoigian { get; set; }
        public string luu_luong_hien_tai { get; set; }
        public string luu_luong_tong { get; set; }
    }
}