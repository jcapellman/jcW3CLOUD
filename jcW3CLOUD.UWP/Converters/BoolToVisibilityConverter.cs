using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace jcW3CLOUD.UWP.Converters {
    public class BoolToVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string languagee) {
            var val = (bool)value;
            bool inverse;

            if (parameter != null && bool.TryParse((string)parameter, out inverse)) {
                val = !val;
            }

            return (val) ? Visibility.Visible : Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return null;
        }
    }
}