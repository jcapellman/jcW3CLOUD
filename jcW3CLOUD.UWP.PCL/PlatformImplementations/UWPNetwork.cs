using System;
using System.Net.NetworkInformation;

using jcW3CLOUD.PCL.PlatformAbstractions;

namespace jcW3CLOUD.UWP.PCL.PlatformImplementations {
    public class UWPNetwork : BaseNetwork {

        public override void PlatformCheck() {
            NetworkChanged += OnNetworkChanged;

            var hasNetwork = NetworkInterface.GetIsNetworkAvailable();
            
            if (hasNetwork && !_isConnected) {
                OnNetworkChanged(this, new NetworkEventArgs(true));
            } else if (hasNetwork && IsConnected()) {
                OnNetworkChanged(this, new NetworkEventArgs(false));
            }
        }

        private void OnNetworkChanged(object sender, NetworkEventArgs networkEventArgs)
        {
            _isConnected = networkEventArgs.IsConnnected;
        }
    }
}