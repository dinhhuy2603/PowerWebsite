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
        private volatile bool _sendingDataKenh2 = false;
        private volatile bool _sendingDataKenh3 = false;
        private volatile bool _sendingDataKenh4 = false;
        private volatile bool _sendingDataKenh5 = false;
        private volatile bool _sendingDataKenh6 = false;
        private volatile bool _sendingDataGas = false;
        private volatile bool _sendingDataWater = false;
        private readonly object _dataUpdateLock_Kenh2 = new object();
        private readonly object _dataUpdateLock_Kenh3 = new object();
        private readonly object _dataUpdateLock_Kenh4 = new object();
        private readonly object _dataUpdateLock_Kenh5 = new object();
        private readonly object _dataUpdateLock_Kenh6 = new object();
        private readonly object _dataUpdateLock_Gas = new object();
        private readonly object _dataUpdateLock_Water = new object();

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
        //public void GetKenh1OnlineData()
        //{
        //    _timer = new Timer(ChartTimerKenh1CallBack, null, _updateInterval, _updateInterval);
        //}
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
            if (_sendingDataGas)
            {
                return;
            }
            lock (_dataUpdateLock_Gas)
            {
                if (!_sendingDataGas)
                {
                    _sendingDataGas = true;
                    SendGasData();
                    _sendingDataGas = false;
                }
            }
        }
        private void ChartTimerWaterCallBack(object state)
        {
            if (_sendingDataWater)
            {
                return;
            }
            lock (_dataUpdateLock_Water)
            {
                if (!_sendingDataWater)
                {
                    _sendingDataWater = true;
                    SendWaterData();
                    _sendingDataWater = false;
                }
            }
        }
        //private void ChartTimerKenh1CallBack(object state)
        //{
        //    if (_sendingData)
        //    {
        //        return;
        //    }
        //    lock (_dataUpdateLock)
        //    {
        //        if (!_sendingData)
        //        {
        //            _sendingData = true;
        //            SendKenh1Data();
        //            _sendingData = false;
        //        }
        //    }
        //}
        private void ChartTimerKenh2CallBack(object state)
        {
            if (_sendingDataKenh2)
            {
                return;
            }
            lock (_dataUpdateLock_Kenh2)
            {
                if (!_sendingDataKenh2)
                {
                    _sendingDataKenh2 = true;
                    SendKenh2Data();
                    _sendingDataKenh2 = false;
                }
            }
        }
        private void ChartTimerKenh3CallBack(object state)
        {
            if (_sendingDataKenh3)
            {
                return;
            }
            lock (_dataUpdateLock_Kenh3)
            {
                if (!_sendingDataKenh3)
                {
                    _sendingDataKenh3 = true;
                    SendKenh3Data();
                    _sendingDataKenh3 = false;
                }
            }
        }
        private void ChartTimerKenh4CallBack(object state)
        {
            if (_sendingDataKenh4)
            {
                return;
            }
            lock (_dataUpdateLock_Kenh4)
            {
                if (!_sendingDataKenh4)
                {
                    _sendingDataKenh4 = true;
                    SendKenh4Data();
                    _sendingDataKenh4 = false;
                }
            }
        }
        private void ChartTimerKenh5CallBack(object state)
        {
            if (_sendingDataKenh5)
            {
                return;
            }
            lock (_dataUpdateLock_Kenh5)
            {
                if (!_sendingDataKenh5)
                {
                    _sendingDataKenh5 = true;
                    SendKenh5Data();
                    _sendingDataKenh5 = false;
                }
            }
        }
        private void ChartTimerKenh6CallBack(object state)
        {
            if (_sendingDataKenh6)
            {
                return;
            }
            lock (_dataUpdateLock_Kenh6)
            {
                if (!_sendingDataKenh6)
                {
                    _sendingDataKenh6 = true;
                    SendKenh6Data();
                    _sendingDataKenh6 = false;
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
        //private void SendKenh1Data()
        //{
        //    var kenh1_data = new Electric1Controller().GetChartKenh1DataOnline().Data;
        //    GetAllClients().All.UpdateKenh1Online(kenh1_data);
        //}
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