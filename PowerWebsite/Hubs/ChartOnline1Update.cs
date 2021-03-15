using Microsoft.AspNet.SignalR;
using PowerWebsite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PowerWebsite.Hubs
{
    public class ChartOnline1Update
    {
        private readonly static Lazy<ChartOnline1Update> _instance = new Lazy<ChartOnline1Update>(() => new ChartOnline1Update());
        readonly int _updateInterval = 1000;
        private Timer _timer;
        private volatile bool _sendingData = false;
        private readonly object _dataUpdateLock = new object();

        private ChartOnline1Update()
        {

        }

        public static ChartOnline1Update Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void GetWaterOnlineData()
        {
            _timer = new Timer(ChartTimerWaterCallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh1OnlineData()
        {
            _timer = new Timer(ChartTimerKenh1CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh2OnlineData()
        {
            _timer = new Timer(ChartTimerKenh2CallBack, null, _updateInterval, _updateInterval);
        }
        public void GetKenh3OnlineData()
        {
            _timer = new Timer(ChartTimerKenh3CallBack, null, _updateInterval, _updateInterval);
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

        private void ChartTimerGasCallBack(object state)
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
                    SendGasData();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerWaterCallBack(object state)
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
                    SendWaterData();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh1CallBack(object state)
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
                    SendKenh1Data();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh2CallBack(object state)
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
                    SendKenh2Data();
                    _sendingData = false;
                }
            }
        }
        private void ChartTimerKenh3CallBack(object state)
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
                    SendKenh3Data();
                    _sendingData = false;
                }
            }
        }
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

        private void SendGasData()
        {
            var gas_data = new GasController().GetGasData().Data;
            GetAllClients().All.UpdateGasOnline(gas_data);
        }
        private void SendWaterData()
        {
            var water_data = new WaterController().GetWaterData().Data;
            GetAllClients().All.UpdateWaterOnline(water_data);
        }
        private void SendKenh1Data()
        {
            var kenh1_data = new Electric1Controller().GetChartKenh1DataOnline().Data;
            GetAllClients().All.UpdateKenh1Online(kenh1_data);
        }
        private void SendKenh2Data()
        {
            var kenh2_data = new Electric1Controller().GetChartKenh2DataOnline().Data;
            GetAllClients().All.UpdateKenh2Online(kenh2_data);
        }
        private void SendKenh3Data()
        {
            var kenh3_data = new Electric1Controller().GetChartKenh3DataOnline().Data;
            GetAllClients().All.UpdateKenh3Online(kenh3_data);
        }
        private void SendKenh4Data()
        {
            var kenh4_data = new Electric1Controller().GetChartKenh4DataOnline().Data;
            GetAllClients().All.UpdateKenh4Online(kenh4_data);
        }
        private void SendKenh5Data()
        {
            var kenh5_data = new Electric1Controller().GetChartKenh5DataOnline().Data;
            GetAllClients().All.UpdateKenh5Online(kenh5_data);
        }
        private void SendKenh6Data()
        {
            var kenh6_data = new Electric1Controller().GetChartKenh6DataOnline().Data;
            GetAllClients().All.UpdateKenh6Online(kenh6_data);
        }

        private static dynamic GetAllClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients;
        }
    }
}