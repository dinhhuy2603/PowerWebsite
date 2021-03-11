using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using PowerWebsite.Controllers;
using PowerWebsite.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Web;

namespace PowerWebsite.Hubs
{

    public class ChartWaterUpdate
    {
        // Singleton instance
        private readonly static Lazy<ChartWaterUpdate> _instance = new Lazy<ChartWaterUpdate>(() => new ChartWaterUpdate());
        // Send Data every 1 seconds
        readonly int _updateInterval = 1000;
        //Timer Class
        private Timer _timer;
        private volatile bool _sendingChartData = false;
        private readonly object _chartUpateLock = new object();

        private ChartWaterUpdate()
        {

        }

        public static ChartWaterUpdate Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        // Calling this method starts the Timer
        public void GetChartWaterData()
        {
            _timer = new Timer(ChartTimerCallBack, null, _updateInterval, _updateInterval);
        }
        private void ChartTimerCallBack(object state)
        {
            if (_sendingChartData)
            {
                return;
            }
            lock (_chartUpateLock)
            {
                if (!_sendingChartData)
                {
                    _sendingChartData = true;
                    SendChartWaterData();
                    _sendingChartData = false;
                }
            }
        }

        private void SendChartWaterData()
        {
            var waterChart = new WaterController().GetWaterData().Data;
            var waterPc15Chart = new WaterController().GetWaterPc15Data().Data;
            GetAllClients().All.UpdateChartWater(waterChart, waterPc15Chart);
        }

        private static dynamic GetAllClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients;
        }
    }
}