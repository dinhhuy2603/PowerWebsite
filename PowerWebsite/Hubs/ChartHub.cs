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
        public ChartHub() : this(ChartDataUpdate.Instance) { }

        public ChartHub(ChartDataUpdate ChartInstance)
        {
            _ChartInstance = ChartInstance;
        }

        public void InitChartDataElectric1()
        {
            //Show Chart initially when InitChartData called first time
            //LineChart lineChart = new LineChart();
            //PieChart pieChart = new PieChart();
            //lineChart.SetLineChartData();
            //pieChart.SetPieChartData();

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

        public void sendKenh(string kenh)
        {
            _ChartInstance.getKenhValue(kenh);
        }
    }
}