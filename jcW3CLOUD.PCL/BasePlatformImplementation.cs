using jcW3CLOUD.PCL.PlatformAbstractions;

namespace jcW3CLOUD.PCL {
    public abstract class BasePlatformImplementation {
        public abstract BaseFileSystem GetFileSystem();

        public abstract BaseSettings GetSettings();
    }
}