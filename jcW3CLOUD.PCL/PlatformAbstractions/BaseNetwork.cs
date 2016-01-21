using System;

namespace jcW3CLOUD.PCL.PlatformAbstractions {
    public class NetworkEventArgs : EventArgs {
        public NetworkEventArgs(bool isConnected) {
            IsConnnected = isConnected;
        } 

        public bool IsConnnected { get; }
    }
    
    public abstract class BaseNetwork {
        protected internal bool _isConnected = false;

        public abstract void PlatformCheck();

        public bool IsConnected() {
            return _isConnected;
        }

        public event EventHandler<NetworkEventArgs> NetworkChanged;
    }
}