using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leave_appz.NetworkModel
{
    public class NetworkManager
    {
        public NetworkManager()
        {

        }

        public bool IsNetworkAvailable()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
                return false;
        }
    }
}
