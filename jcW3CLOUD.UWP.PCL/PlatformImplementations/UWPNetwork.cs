using System.Net.NetworkInformation;

using jcW3CLOUD.PCL.PlatformAbstractions;

namespace jcW3CLOUD.UWP.PCL.PlatformImplementations {
    public class UWPNetwork : BaseNetwork {

        public override void PlatformCheck() {
            var hasNetwork = NetworkInterface.GetIsNetworkAvailable();
            
            if (hasNetwork && !_isConnected) {
                OnNetworkChanged(new NetworkEventArgs(true));
            } else if (hasNetwork && IsConnected()) {
                OnNetworkChanged(new NetworkEventArgs(false));
            }
        }
    }
}