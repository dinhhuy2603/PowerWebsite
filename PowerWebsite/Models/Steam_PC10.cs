using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PowerWebsite.Models
{
    [Table("hienthi1_steam_pc10")]
    public class Steam_PC10
    {
        [Key]
        public int idsteam { get; set; }
        public string luu_luong_hien_tai { get; set; }
        public string luu_luong_tong { get; set; }
        public int status { get; set; }
    }
    public class SteamPC10View
    {
        [Key]
        public int idsteam { get; set; }
        public string luu_luong_hien_tai { get; set; }
        public string luu_luong_tong { get; set; }
        public int status { get; set; }
        public string luu_luong_tong_ngay { get; set; }
    }
}