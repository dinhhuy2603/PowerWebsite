using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using PowerWebsite.Models;
using PowerWebsite.Controllers;

namespace PowerWebsite.Hubs
{
    public class ChartHub : Hub
    {
        // Create the instance of ChartDataUpdate
        private readonly ChartElectric1Update _Electric1;
        private readonly ChartElectric2Update _Electric2;
        private readonly EnergyDatatUpdate _EneryInstance;
        private readonly ChartOnline1Update _ChartOnline1Instance;
        private readonly ChartOnline2Update _ChartOnline2Instance;
        private readonly ChartGasUpdate _GasSnackInstance;
        private readonly ChartWaterUpdate _WaterSnackInstance;
        private readonly ChartSteamUpdate _SteamSnackInstance;
        private readonly ChartSolar_LogisticUpdate _SolarLogisInstance;
        public ChartHub() : this(ChartElectric1Update.Instance, ChartElectric2Update.Instance, EnergyDatatUpdate.Instance, ChartOnline1Update.Instance, ChartOnline2Update.Instance,
            ChartGasUpdate.Instance, ChartWaterUpdate.Instance, ChartSteamUpdate.Instance, ChartSolar_LogisticUpdate.Instance) { }

        public ChartHub(ChartElectric1Update Electric1Instance, ChartElectric2Update Electric2Instance, EnergyDatatUpdate EneryInstance, ChartOnline1Update ChartOnline1Instance, ChartOnline2Update ChartOnline2Instance, 
            ChartGasUpdate GasSnackInstance, ChartWaterUpdate WaterSnackInstance, ChartSteamUpdate SteamSnackInstance, ChartSolar_LogisticUpdate SolarLogisInstance)
        {
            _Electric1 = Electric1Instance;
            _Electric2 = Electric2Instance;
            _EneryInstance = EneryInstance;
            _ChartOnline1Instance = ChartOnline1Instance;
            _ChartOnline2Instance = ChartOnline2Instance;
            _GasSnackInstance = GasSnackInstance;
            _WaterSnackInstance = WaterSnackInstance;
            _SteamSnackInstance = SteamSnackInstance;
            _SolarLogisInstance = SolarLogisInstance;
        }
        // Dashboard Electric 1-2
        public void InitChartDataElectric1()
        {
            var gasChart = new GasController().GetGasData().Data;
            var waterChart = new WaterController().GetWaterData().Data;
            var kenh1Chart = new HomeController().GetChartKenh1Data().Data;
            var kenh2Chart = new HomeController().GetChartKenh2Data().Data;
            var kenh3Chart = new HomeController().GetChartKenh3Data().Data;
            var kenh4Chart = new HomeController().GetChartKenh4Data().Data;
            var kenh5Chart = new HomeController().GetChartKenh5Data().Data;
            var kenh6Chart = new HomeController().GetChartKenh6Data().Data;
            Clients.All.UpdateChartElectric1(kenh1Chart, kenh2Chart, kenh3Chart, kenh4Chart, kenh5Chart, kenh6Chart);
            //Call GetChartData to send Chart data every 5 seconds
            _Electric1.GetChartElectric1Data();
        }
        public void sendKenhElectric1(string kenh)
        {
            _Electric1.getKenhValue(kenh);
            var dataHienthi = new HomeController().GetHienThiData(kenh).Data;
            Clients.All.UpdatePopupHienThi(dataHienthi);
        }

        // Dashboard Electric 2-2
        public void InitChartDataElectric2()
        {
            var kenh4Chart = new SnackController().GetChartKenh4Data().Data;
            var kenh5Chart = new SnackController().GetChartKenh5Data().Data;
            var kenh6Chart = new SnackController().GetChartKenh6Data().Data;
            var kenh7Chart = new SnackController().GetChartKenh7Data().Data;
            var kenh8Chart = new SnackController().GetChartKenh8Data().Data;
            var kenh9Chart = new SnackController().GetChartKenh9Data().Data;
            var kenh10Chart = new SnackController().GetChartKenh10Data().Data;
            var kenh11Chart = new SnackController().GetChartKenh11Data().Data;
            Clients.All.UpdateChartElectric2(kenh4Chart, kenh5Chart, kenh6Chart, kenh7Chart, kenh8Chart, kenh9Chart, kenh10Chart, kenh11Chart);
            //Call GetChartData to send Chart data every 5 seconds
            _Electric2.GetChartElectric2Data();
        }
        public void sendKenhElectric2(string kenh)
        {
            _Electric2.getKenhValue(kenh);
            var dataHienthi1 = new SnackController().GetHienThi1Data(kenh).Data;
            Clients.All.UpdatePopupHienThi(dataHienthi1);
        }

        // Dashboard Gas
        public void InitChartGasDashboard()
        {
            var gasChart = new GasController().GetGasData().Data;
            var gasCngChart = new GasController().GetGasCNGData().Data;
            Clients.All.UpdateChartGas(gasChart, gasCngChart);
            _GasSnackInstance.GetChartGasData();
        }

        //Dashboard Water
        public void InitChartWaterDashboard()
        {
            var waterChart = new WaterController().GetWaterData().Data;
            var waterPc15Chart = new WaterController().GetWaterPc15Data().Data;
            Clients.All.UpdateChartWater(waterChart, waterPc15Chart);
            _WaterSnackInstance.GetChartWaterData();
        }
        
        // Dashboard Steam
        public void InitChartSteamDashboard()
        {
            var steamPc10Chart = new SteamController().GetSteamPc10Data().Data;
            var steamPc15Chart = new SteamController().GetSteamPc15Data().Data;
            Clients.All.UpdateChartSteam(steamPc10Chart, steamPc15Chart);
            _SteamSnackInstance.GetChartSteamData();
        }

        // Dashboard Năng lượng mặt trời
        public void InitChartDataSolar()
        {
            var solar1Chart = new SnackController().GetChartSolar1Data().Data;
            var solar2Chart = new SnackController().GetChartSolar2Data().Data;
            Clients.All.UpdateChartSolar(solar1Chart, solar2Chart);
            //Call GetChartData to send Chart data every 5 seconds
            _SolarLogisInstance.GetChartSolarData();
        }
        public void sendKenhSolar(string kenh)
        {
            _SolarLogisInstance.getKenhValue(kenh);
            var dataHienthi1 = new SnackController().GetHienThi1Data(kenh).Data;
            Clients.All.UpdatePopupSolar(dataHienthi1);
        }
        // Dashboard Kho Logistic
        public void InitChartDataLogistic()
        {
            var logisticChart = new SnackController().GetChartLogisticsData().Data;
            Clients.All.UpdateChartLogistic(logisticChart);
            //Call GetChartData to send Chart data every 5 seconds
            _SolarLogisInstance.GetChartLogisticsData();
        }
        public void sendKenhLogistic(string kenh)
        {
            _SolarLogisInstance.getKenhLogisticValue(kenh);
            var dataHienthi1 = new SnackController().GetHienThi1Data(kenh).Data;
            Clients.All.UpdatePopupLogistic(dataHienthi1);
        }


        // Energy Overview
        public void InitEneryOveriew()
        {
            var hienthi_enery_overview = new HomeController().GetIndexData().Data;
            Clients.All.UpdateEneryOverview(hienthi_enery_overview);
            _EneryInstance.GetEnergyOverviewData();
        }

        // Chart Online Electric 1-2
        public void InitChartKenh1Online()
        {
            var kenh1_data = new Electric1Controller().GetChartKenh1DataOnline().Data;
            Clients.All.UpdateKenh1Online(kenh1_data);
            _ChartOnline1Instance.GetKenh1OnlineData();
        }

        public void InitChartKenh2Online()
        {
            var kenh2_data = new Electric1Controller().GetChartKenh2DataOnline().Data;
            Clients.All.UpdateKenh2Online(kenh2_data);
            _ChartOnline1Instance.GetKenh2OnlineData();
        }
        public void InitChartKenh3Online()
        {
            var kenh3_data = new Electric1Controller().GetChartKenh3DataOnline().Data;
            Clients.All.UpdateKenh3Online(kenh3_data);
            _ChartOnline1Instance.GetKenh3OnlineData();
        }
        public void InitChartKenh4Online()
        {
            var kenh4_data = new Electric1Controller().GetChartKenh4DataOnline().Data;
            Clients.All.UpdateKenh4Online(kenh4_data);
            _ChartOnline1Instance.GetKenh4OnlineData();
        }
        public void InitChartKenh5Online()
        {
            var kenh5_data = new Electric1Controller().GetChartKenh5DataOnline().Data;
            Clients.All.UpdateKenh5Online(kenh5_data);
            _ChartOnline1Instance.GetKenh5OnlineData();
        }
        public void InitChartKenh6Online()
        {
            var kenh6_data = new Electric1Controller().GetChartKenh6DataOnline().Data;
            Clients.All.UpdateKenh6Online(kenh6_data);
            _ChartOnline1Instance.GetKenh6OnlineData();
        }

        // Chart Online Electric 2-2
        public void InitChartKenh4Online2()
        {
            var kenh4_data = new Electric2Controller().GetChartKenh4DataOnline().Data;
            Clients.All.UpdateKenh4Online2(kenh4_data);
            _ChartOnline2Instance.GetKenh4OnlineData();
        }
        public void InitChartKenh5Online2()
        {
            var kenh5_data = new Electric2Controller().GetChartKenh5DataOnline().Data;
            Clients.All.UpdateKenh5Online2(kenh5_data);
            _ChartOnline2Instance.GetKenh5OnlineData();
        }
        public void InitChartKenh6Online2()
        {
            var kenh6_data = new Electric2Controller().GetChartKenh6DataOnline().Data;
            Clients.All.UpdateKenh6Online2(kenh6_data);
            _ChartOnline2Instance.GetKenh6OnlineData();
        }
        public void InitChartKenh7Online2()
        {
            var kenh7_data = new Electric2Controller().GetChartKenh7DataOnline().Data;
            Clients.All.UpdateKenh7Online2(kenh7_data);
            _ChartOnline2Instance.GetKenh7OnlineData();
        }
        public void InitChartKenh8Online2()
        {
            var kenh8_data = new Electric2Controller().GetChartKenh8DataOnline().Data;
            Clients.All.UpdateKenh8Online2(kenh8_data);
            _ChartOnline2Instance.GetKenh8OnlineData();
        }
        public void InitChartKenh9Online2()
        {
            var kenh9_data = new Electric2Controller().GetChartKenh9DataOnline().Data;
            Clients.All.UpdateKenh9Online2(kenh9_data);
            _ChartOnline2Instance.GetKenh9OnlineData();
        }
        public void InitChartKenh10Online2()
        {
            var kenh10_data = new Electric2Controller().GetChartKenh10DataOnline().Data;
            Clients.All.UpdateKenh10Online2(kenh10_data);
            _ChartOnline2Instance.GetKenh10OnlineData();
        }
        public void InitChartKenh11Online2()
        {
            var kenh11_data = new Electric2Controller().GetChartKenh11DataOnline().Data;
            Clients.All.UpdateKenh11Online2(kenh11_data);
            _ChartOnline2Instance.GetKenh11OnlineData();
        }
        // Chart Gas Online
        public void InitChartGasOnline()
        {
            var gas_data = new GasController().GetGasData().Data;
            Clients.All.UpdateGasOnline(gas_data);
            _GasSnackInstance.GetGasOnlineData();
        }
        public void InitChartGasCNGOnline()
        {
            var gas_cng_data = new GasController().GetGasCNGData().Data;
            Clients.All.UpdateGasCNGOnline(gas_cng_data);
            _GasSnackInstance.GetGasCNGOnlineData();
        }
        // Chart Water Online
        public void InitChartWaterOnline()
        {
            var water_data = new WaterController().GetWaterData().Data;
            Clients.All.UpdateWaterOnline(water_data);
            _WaterSnackInstance.GetWaterOnlineData();
        }
    }
}