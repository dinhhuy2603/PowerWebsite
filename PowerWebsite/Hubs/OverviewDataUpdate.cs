using Microsoft.AspNet.SignalR;
using PowerWebsite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PowerWebsite.Hubs
{
    public class OverviewDatatUpdate
    {
        private readonly static Lazy<OverviewDatatUpdate> _instance = new Lazy<OverviewDatatUpdate>(() => new OverviewDatatUpdate());
        readonly int _updateInterval = 1000;
        private Timer _timer;
        private volatile bool _sendingData = false;
        private readonly object _dataUpdateLock = new object();

        private OverviewDatatUpdate()
        {

        }

        public static OverviewDatatUpdate Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void GetOverviewData()
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
                    SendOverViewData();
                    _sendingData = false;
                }
            }
        }

        private void SendOverViewData()
        {
            var hienthi_overview = new OverviewController().GetOverViewData().Data;
            GetAllClients().All.UpdateOverview(hienthi_overview);
        }

        private static dynamic GetAllClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients;
        }
    }
}