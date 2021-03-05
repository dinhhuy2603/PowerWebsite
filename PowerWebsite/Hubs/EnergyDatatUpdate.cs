using Microsoft.AspNet.SignalR;
using PowerWebsite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PowerWebsite.Hubs
{
    public class EnergyDatatUpdate
    {
        private readonly static Lazy<EnergyDatatUpdate> _instance = new Lazy<EnergyDatatUpdate>(() => new EnergyDatatUpdate());
        readonly int _updateInterval = 1000;
        private Timer _timer;
        private volatile bool _sendingData = false;
        private readonly object _dataUpdateLock = new object();

        private EnergyDatatUpdate()
        {

        }

        public static EnergyDatatUpdate Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void GetEnergyOverviewData()
        {
            _timer = new Timer(ChartTimerCallBack, null, _updateInterval, _updateInterval);
        }

        private void ChartTimerCallBack(object state)
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
                    SendEnergyData();
                    _sendingData = false;
                }
            }
        }

        private void SendEnergyData()
        {
            var hienthi_enery_overview = new HomeController().GetIndexData().Data;
            GetAllClients().All.UpdateEneryOverview(hienthi_enery_overview);
        }

        private static dynamic GetAllClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients;
        }
    }
}