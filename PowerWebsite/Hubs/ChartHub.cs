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
        private readonly ChartDataUpdate _ChartInstance;
        private readonly EnergyDatatUpdate _EneryInstance;
        private readonly ChartOnlineUpdate _ChartOnlineInstance;
        public ChartHub() : this(ChartDataUpdate.Instance, EnergyDatatUpdate.Instance, ChartOnlineUpdate.Instance) { }

        public ChartHub(ChartDataUpdate ChartInstance, EnergyDatatUpdate EneryInstance, ChartOnlineUpdate ChartOnlineInstance)
        {
            _ChartInstance = ChartInstance;
            _EneryInstance = EneryInstance;
            _ChartOnlineInstance = ChartOnlineInstance;
        }

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
            Clients.All.UpdateChartElectric1(gasChart, waterChart, kenh1Chart, kenh2Chart, kenh3Chart, kenh4Chart, kenh5Chart, kenh6Chart);
            //Call GetChartData to send Chart data every 5 seconds
            _ChartInstance.GetChartElectric1Data();
        }

        public void InitEneryOveriew()
        {
            var hienthi_enery_overview = new HomeController().GetIndexData().Data;
            Clients.All.UpdateEneryOverview(hienthi_enery_overview);
            _EneryInstance.GetEnergyOverviewData();
        }

        public void sendKenh(string kenh)
        {
            _ChartInstance.getKenhValue(kenh);
            var dataHienthi = new HomeController().GetHienThiData(kenh).Data;
            Clients.All.UpdatePopupHienThi(dataHienthi);
        }

        public void InitChartGasOnline()
        {
            var gas_data = new GasController().GetGasData().Data;
            Clients.All.UpdateGasOnline(gas_data);
            _ChartOnlineInstance.GetGasOnlineData();
        }
        public void InitChartWaterOnline()
        {
            var water_data = new WaterController().GetWaterData().Data;
            Clients.All.UpdateWaterOnline(water_data);
            _ChartOnlineInstance.GetWaterOnlineData();
        }
        public void InitChartKenh1Online()
        {
            var kenh1_data = new KenhController().GetChartKenh1DataOnline().Data;
            Clients.All.UpdateKenh1Online(kenh1_data);
            _ChartOnlineInstance.GetKenh1OnlineData();
        }
       
    }
}