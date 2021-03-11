using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace PowerWebsite.Models
{
    public class DBModel : DbContext
    {
        public DBModel()
            : base("name=PowerEntities")
        {
        }

        public DbSet<UserAccount> useraccount { get; set; }
        public DbSet<Gas> gas { get; set; }
        public DbSet<GasView> gas_view { get; set; }
        public DbSet<Water> water { get; set; }
        public DbSet<WaterView> water_view { get; set; }
        public DbSet<Hienthi> hienthi { get; set; }
        public DbSet<HienthiView> hienthi_view { get; set; }
        public DbSet<Recoder_Gas> recoder_gas { get; set; }
        public DbSet<Recoder_Water> recoder_water { get; set; }
        public DbSet<Recoder_DongHo1> recoder_kenh1 { get; set; }
        public DbSet<Recoder_DongHo2> recoder_kenh2 { get; set; }
        public DbSet<Recoder_DongHo3> recoder_kenh3 { get; set; }
        public DbSet<Recoder_DongHo4> recoder_kenh4 { get; set; }
        public DbSet<Recoder_DongHo5> recoder_kenh5 { get; set; }
        public DbSet<Recoder_DongHo6> recoder_kenh6 { get; set; }
        public DbSet<Hienthi1> hienthi1 { get; set; }
        public DbSet<Hienthi1View> hienthi1_view { get; set; }
        public DbSet<Recoder1_DB_PC15> recoder1_kenh4 { get; set; }
        public DbSet<Recoder1_DB_PC10> recoder1_kenh5 { get; set; }
        public DbSet<Recoder1_DB_Snack1> recoder1_kenh6 { get; set; }
        public DbSet<Recoder1_DB_Snack2> recoder1_kenh7 { get; set; }
        public DbSet<Recoder1_DB_Snack3> recoder1_kenh8 { get; set; }
        public DbSet<Recoder1_DB_Snack4> recoder1_kenh9 { get; set; }
        public DbSet<Recoder1_LP_PC15> recoder1_kenh10 { get; set; }
        public DbSet<Recoder1_LP_Snack1> recoder1_kenh11 { get; set; }
        public DbSet<GasCNG_PC15> gas_cng { get; set; }
        public DbSet<GasCNGView> gas_cng_view { get; set; }
        public DbSet<Recoder1_CNG_PC15> recoder1_gas_cng { get; set; }
        public DbSet<Water_PC15> water_pc15 { get; set; }
        public DbSet<WaterPC15View> water_pc15_view { get; set; }
        public DbSet<Recoder1_Water_PC15> recoder1_water_pc15 { get; set; }
        public DbSet<Steam_PC10> steam_pc10 { get; set; }
        public DbSet<SteamPC10View> steam_pc10_view { get; set; }
        public DbSet<Recoder1_Steam_PC10> recoder1_steam_pc10 { get; set; }
        public DbSet<Steam_PC15> steam_pc15 { get; set; }
        public DbSet<SteamPC15View> steam_pc15_view { get; set; }
        public DbSet<Recoder1_Steam_PC15> recoder1_steam_pc15 { get; set; }
        public DbSet<Recoder1_DB_Solar1> recoder1_db_solar1 { get; set; }
        public DbSet<Recoder1_DB_Solar2> recoder1_db_solar2 { get; set; }
        public DbSet<Recoder1_DB_Logistics> recoder1_db_logistics { get; set; }



    }
}