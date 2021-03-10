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
    public class ChartElectric2Update
    {
        // Singleton instance
        private readonly static Lazy<ChartElectric2Update> _instance = new Lazy<ChartElectric2Update>(() => new ChartElectric2Update());
        readonly int _updateInterval = 1000;
        //Timer Class
        private Timer _timer;
        private volatile bool _sendingChartData = false;
        private readonly object _chartUpateLock = new object();
        private static string kenh = "4";

        private ChartElectric2Update()
        {

        }

        public static ChartElectric2Update Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        // Calling this method starts the Timer
        public void GetChartElectric2Data()
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
                    SendChartElectric2Data();
                    // Cập nhập popup;
                    sendPopupHienThi1Data();
                    _sendingChartData = false;
                }
            }
        }
        private void SendChartElectric2Data()
        {
            var kenh4Chart = new SnackController().GetChartKenh4Data().Data;
            var kenh5Chart = new SnackController().GetChartKenh5Data().Data;
            var kenh6Chart = new SnackController().GetChartKenh6Data().Data;
            var kenh7Chart = new SnackController().GetChartKenh7Data().Data;
            var kenh8Chart = new SnackController().GetChartKenh8Data().Data;
            var kenh9Chart = new SnackController().GetChartKenh9Data().Data;
            var kenh10Chart = new SnackController().GetChartKenh10Data().Data;
            var kenh11Chart = new SnackController().GetChartKenh11Data().Data;
            GetAllClients().All.UpdateChartElectric2(kenh4Chart, kenh5Chart, kenh6Chart, kenh7Chart, kenh8Chart, kenh9Chart, kenh10Chart, kenh11Chart);
        }

        private void sendPopupHienThi1Data()
        {
            var dataHienthi1 = new SnackController().GetHienThi1Data(kenh).Data;
            GetAllClients().All.UpdatePopupHienThi1(dataHienthi1);
        }

        private static dynamic GetAllClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients;
        }
        public string getKenhValue(string kenhValue)
        {
            return kenh = kenhValue;
        }

    }
}