using Microsoft.AspNet.SignalR;
using PowerWebsite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PowerWebsite.Hubs
{
    public class ChartOnline2Update
    {
        private readonly static Lazy<ChartOnline2Update> _instance = new Lazy<ChartOnline2Update>(() => new ChartOnline2Update());
        readonly int _updateInterval = 1000;
        private Timer _timer;
        private volatile bool _sendingData = false;
        private readonly object _dataUpdateLock = new object();

        private ChartOnline2Update()
        {

        }
        public static ChartOnline2Update Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        public void GetKenh4OnlineData()
        {
            _timer = new Timer(ChartTimerKenh4CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh5OnlineData()
        {
            _timer = new Timer(ChartTimerKenh5CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh6OnlineData()
        {
            _timer = new Timer(ChartTimerKenh6CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh7OnlineData()
        {
            _timer = new Timer(ChartTimerKenh7CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh8OnlineData()
        {
            _timer = new Timer(ChartTimerKenh8CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh9OnlineData()
        {
            _timer = new Timer(ChartTimerKenh9CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh10OnlineData()
        {
            _timer = new Timer(ChartTimerKenh10CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh11OnlineData()
        {
            _timer = new Timer(ChartTimerKenh11CallBack, null, _updateInterval, _updateInterval);
        }
        // TimerCallback
        private void ChartTimerKenh4CallBack(object state)
        {
            if (_sendingData)
            {
                return;
            }
            lock (_dataUpdateLock)
            {
                if (!_sendingData)
                {
                    _sendingData = true;
                    SendKenh4Data();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh5CallBack(object state)
        {
            if (_sendingData)
            {
                return;
            }
            lock (_dataUpdateLock)
            {
                if (!_sendingData)
                {
                    _sendingData = true;
                    SendKenh5Data();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh6CallBack(object state)
        {
            if (_sendingData)
            {
                return;
            }
            lock (_dataUpdateLock)
            {
                if (!_sendingData)
                {
                    _sendingData = true;
                    SendKenh6Data();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh7CallBack(object state)
        {
            if (_sendingData)
            {
                return;
            }
            lock (_dataUpdateLock)
            {
                if (!_sendingData)
                {
                    _sendingData = true;
                    SendKenh7Data();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh8CallBack(object state)
        {
            if (_sendingData)
            {
                return;
            }
            lock (_dataUpdateLock)
            {
                if (!_sendingData)
                {
                    _sendingData = true;
                    SendKenh8Data();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh9CallBack(object state)
        {
            if (_sendingData)
            {
                return;
            }
            lock (_dataUpdateLock)
            {
                if (!_sendingData)
                {
                    _sendingData = true;
                    SendKenh9Data();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh10CallBack(object state)
        {
            if (_sendingData)
            {
                return;
            }
            lock (_dataUpdateLock)
            {
                if (!_sendingData)
                {
                    _sendingData = true;
                    SendKenh10Data();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh11CallBack(object state)
        {
            if (_sendingData)
            {
                return;
            }
            lock (_dataUpdateLock)
            {
                if (!_sendingData)
                {
                    _sendingData = true;
                    SendKenh11Data();
                    _sendingData = false;
                }
            }
        }

        // Send Data
        private void SendKenh4Data()
        {
            var kenh4_data = new Electric2Controller().GetChartKenh4DataOnline().Data;
            GetAllClients().All.UpdateKenh4Online2(kenh4_data);
        }
        private void SendKenh5Data()
        {
            var kenh5_data = new Electric2Controller().GetChartKenh5DataOnline().Data;
            GetAllClients().All.UpdateKenh5Online2(kenh5_data);
        }
        private void SendKenh6Data()
        {
            var kenh6_data = new Electric2Controller().GetChartKenh6DataOnline().Data;
            GetAllClients().All.UpdateKenh6Online2(kenh6_data);
        }
        private void SendKenh7Data()
        {
            var kenh7_data = new Electric2Controller().GetChartKenh7DataOnline().Data;
            GetAllClients().All.UpdateKenh7Online2(kenh7_data);
        }
        private void SendKenh8Data()
        {
            var kenh8_data = new Electric2Controller().GetChartKenh8DataOnline().Data;
            GetAllClients().All.UpdateKenh8Online2(kenh8_data);
        }
        private void SendKenh9Data()
        {
            var kenh9_data = new Electric2Controller().GetChartKenh9DataOnline().Data;
            GetAllClients().All.UpdateKenh9Online2(kenh9_data);
        }
        private void SendKenh10Data()
        {
            var kenh10_data = new Electric2Controller().GetChartKenh10DataOnline().Data;
            GetAllClients().All.UpdateKenh10Online2(kenh10_data);
        }
        private void SendKenh11Data()
        {
            var kenh11_data = new Electric2Controller().GetChartKenh11DataOnline().Data;
            GetAllClients().All.UpdateKenh11Online2(kenh11_data);
        }

        private static dynamic GetAllClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients;
        }
    }
}