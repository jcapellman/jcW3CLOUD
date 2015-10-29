using jcW3CLOUD.PCL;
using jcW3CLOUD.PCL.PlatformAbstractions;
using jcW3CLOUD.UWP.PCL.PlatformImplementations;

namespace jcW3CLOUD.UWP.PCL {
    public class UWPPI : BasePlatformImplementation {
        public override BaseFileSystem GetFileSystem() { return new FileSystem(); }

        public override BaseSettings GetSettings() {
            return new Settings();
        }

        public override BaseNetwork GetNetwork() {
            return new UWPNetwork();
        }
    }
}