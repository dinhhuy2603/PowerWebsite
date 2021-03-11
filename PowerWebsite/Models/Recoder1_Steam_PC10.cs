using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PowerWebsite.Models
{
    [Table("recoder1_steam_pc10")]
    public class Recoder1_Steam_PC10
    {
        [Key]
        public DateTime Thoigian { get; set; }
        public string luu_luong_hien_tai { get; set; }
        public string luu_luong_tong { get; set; }
    }
}