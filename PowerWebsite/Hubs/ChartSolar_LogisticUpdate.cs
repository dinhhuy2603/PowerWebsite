using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using PowerWebsite.Controllers;
using PowerWebsite.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static string kenhLogic = "3";

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
        public void GetSolar1OnlineData()
        {
            _timer = new Timer(ChartTimerSolar1OnlineCallBack, null, _updateInterval, _updateInterval);
        }
        public void GetSolar2OnlineData()
        {
            _timer = new Timer(ChartTimerSolar2OnlineCallBack, null, _updateInterval, _updateInterval);
        }
        public void GetLogisticOnlineData()
        {
            _timer = new Timer(ChartTimerLogisticOnlineCallBack, null, _updateInterval, _updateInterval);
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
        private void ChartTimerSolar1OnlineCallBack(object state)
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
                    SendChartSolar1OnlineData();
                    _sendingChartData = false;
                }
            }
        }
        private void ChartTimerSolar2OnlineCallBack(object state)
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
                    SendChartSolar2OnlineData();
                    _sendingChartData = false;
                }
            }
        }
        private void ChartTimerLogisticOnlineCallBack(object state)
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
                    SendChartLogisticOnlineData();
                    _sendingChartData = false;
                }
            }
        }
        
        // Send data chart Dashboard
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
        
        // Send data chart Online
        private void SendChartSolar1OnlineData()
        {
            var solar1_data = new Solar_LogisticController().GetChartSolar1DataOnline().Data;
            GetAllClients().All.UpdateSolar1Online(solar1_data);
        }
        private void SendChartSolar2OnlineData()
        {
            var solar2_data = new Solar_LogisticController().GetChartSolar2DataOnline().Data;
            Debug.Write(1);
            GetAllClients().All.UpdateSolar2Online(solar2_data);
        }
        private void SendChartLogisticOnlineData()
        {
            var logistic_data = new Solar_LogisticController().GetChartLogisticDataOnline().Data;
            Debug.Write(2);
            GetAllClients().All.UpdateLogisticOnline(logistic_data);
        }

        // Get Client Functions
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