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

    public class ChartSteamUpdate
    {
        // Singleton instance
        private readonly static Lazy<ChartSteamUpdate> _instance = new Lazy<ChartSteamUpdate>(() => new ChartSteamUpdate());
        // Send Data every 1 seconds
        readonly int _updateInterval = 1000;
        //Timer Class
        private Timer _timer;
        private volatile bool _sendingChartData = false;
        private readonly object _chartUpateLock = new object();

        private ChartSteamUpdate()
        {

        }

        public static ChartSteamUpdate Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        // Calling this method starts the Timer
        public void GetChartSteamData()
        {
            _timer = new Timer(ChartTimerCallBack, null, _updateInterval, _updateInterval);
        }
        public void GetSteamPc10OnlineData()
        {
            _timer = new Timer(ChartTimerSteamPc10CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetSteamPc15OnlineData()
        {
            _timer = new Timer(ChartTimerSteamPc15CallBack, null, _updateInterval, _updateInterval);
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
                    SendChartSteamData();
                    _sendingChartData = false;
                }
            }
        }
        private void ChartTimerSteamPc10CallBack(object state)
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
                    SendChartSteamPc10Data();
                    _sendingChartData = false;
                }
            }
        }
       
        private void ChartTimerSteamPc15CallBack(object state)
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
                    SendChartSteamPc15Data();
                    _sendingChartData = false;
                }
            }
        }
        private void SendChartSteamPc10Data()
        {
            var steam_pc_10 = new SteamController().GetSteamPc10Data().Data;
            GetAllClients().All.UpdateSteamPc10Online(steam_pc_10);
        }

        private void SendChartSteamPc15Data()
        {
            var steam_pc_15 = new SteamController().GetSteamPc15Data().Data;
            GetAllClients().All.UpdateSteamPc15Online(steam_pc_15);
        }

        private void SendChartSteamData()
        {
            var steamPc10Chart = new SteamController().GetSteamPc10Data().Data;
            var steamPc15Chart = new SteamController().GetSteamPc15Data().Data;
            GetAllClients().All.UpdateChartSteam(steamPc10Chart, steamPc15Chart);
        }

        private static dynamic GetAllClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients;
        }
    }
}