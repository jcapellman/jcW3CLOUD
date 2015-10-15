using jcW3CLOUD.PCL.Enums;

namespace jcW3CLOUD.PCL.PlatformAbstractions {
    public abstract class BaseSettings : BasePA {
        public abstract T GetSetting<T>(SETTINGS setting);

        public abstract void WriteSetting<T>(SETTINGS setting, T value);
    }
}