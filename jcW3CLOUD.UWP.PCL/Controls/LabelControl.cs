using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

using jcW3CLOUD.PCL.BaseControls;

namespace jcW3CLOUD.UWP.PCL.Controls {
    public class LabelControl : BaseLabelControl {
        public override dynamic GetPlatformControl() {
            var textBlock = new TextBlock {
                Margin = new Thickness(10, 10, 10, 10),
                Text = LabelContent,
                Foreground = new SolidColorBrush {Color = Colors.White},
                IsTextSelectionEnabled = true
            };
            
            if (IsFullScreen) {
                textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                textBlock.TextWrapping = TextWrapping.Wrap;
            } else {
                textBlock.Width = Width;
                textBlock.Height = Height;
            }

            return textBlock;
        }
    }
}