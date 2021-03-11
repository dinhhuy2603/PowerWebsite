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
    public class ChartSolar_LogisticUpdate
    {
        // Singleton instance
        private readonly static Lazy<ChartSolar_LogisticUpdate> _instance = new Lazy<ChartSolar_LogisticUpdate>(() => new ChartSolar_LogisticUpdate());
        readonly int _updateInterval = 1000;
        //Timer Class
        private Timer _timer;
        private volatile bool _sendingChartData = false;
        private readonly object _chartUpateLock = new object();
        private static string kenh = "1";
        private static string kenhLogic = "1";

        private ChartSolar_LogisticUpdate()
        {

        }

        public static ChartSolar_LogisticUpdate Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        // Calling this method starts the Timer
        public void GetChartSolarData()
        {
            _timer = new Timer(ChartTimerSolarCallBack, null, _updateInterval, _updateInterval);
        }
        public void GetChartLogisticsData()
        {
            _timer = new Timer(ChartTimerLogisticsCallBack, null, _updateInterval, _updateInterval);
        }
        private void ChartTimerSolarCallBack(object state)
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
                    SendChartSolarData();
                    SendPopupSolarData();
                    _sendingChartData = false;
                }
            }
        }
        private void ChartTimerLogisticsCallBack(object state)
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
                    SendChartLogisticsData();
                    SendPopupLogisticData();
                    _sendingChartData = false;
                }
            }
        }
        private void SendChartSolarData()
        {
            var solar1Chart = new SnackController().GetChartSolar1Data().Data;
            var solar2Chart = new SnackController().GetChartSolar2Data().Data;
            GetAllClients().All.UpdateChartSolar(solar1Chart, solar2Chart);
        }
        private void SendPopupSolarData()
        {
            var dataSolar = new SnackController().GetHienThi1Data(kenh).Data;
            GetAllClients().All.UpdatePopupSolar(dataSolar);
        }
        private void SendChartLogisticsData()
        {
            var logisticChart = new SnackController().GetChartLogisticsData().Data;
            GetAllClients().All.UpdateChartLogistic(logisticChart);
        }
        private void SendPopupLogisticData()
        {
            var dataLogistic = new SnackController().GetHienThi1Data(kenhLogic).Data;
            GetAllClients().All.UpdatePopupLogistic(dataLogistic);
        }


        private static dynamic GetAllClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients;
        }
        public string getKenhValue(string kenhValue)
        {
            return kenh = kenhValue;
        }
        public string getKenhLogisticValue(string kenhLogicValue)
        {
            return kenhLogic = kenhLogicValue;
        }


    }
}