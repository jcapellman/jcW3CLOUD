using jcW3CLOUD.PCL.Enums;
using jcW3CLOUD.PCL.PlatformAbstractions;

namespace jcW3CLOUD.UWP.PCL.PlatformImplementations {
    public class Settings : BaseSettings {
        private readonly Windows.Storage.ApplicationDataContainer _localSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

        public override T GetSetting<T>(SETTINGS setting) {
            if (!_localSettings.Values.ContainsKey(setting.ToString())) {
                return default(T);
            }

            return (T)_localSettings.Values[setting.ToString()];
        }

        public override void WriteSetting<T>(SETTINGS setting, T value) {
            _localSettings.Values[setting.ToString()] = value;
        }
    }
}