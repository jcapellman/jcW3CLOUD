using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

using jcW3CLOUD.PCL.ViewModels;
using jcW3CLOUD.UWP.PCL;

namespace jcW3CLOUD.UWP {
    public sealed partial class MainPage : Page {
        private MainModel viewModel => (MainModel) DataContext;

        public MainPage() {
            InitializeComponent();

            DataContext = new MainModel(new UWPControls());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            icMain.Focus(FocusState.Programmatic);
        }

        public void mfiExit_OnClick(object sender, RoutedEventArgs e) {
            Application.Current.Exit();
        }

        private async void txtBxURL_OnKeyDown(object sender, KeyRoutedEventArgs e) {
            if (e.Key == VirtualKey.Enter) {
                icMain.Focus(FocusState.Programmatic);

                await viewModel.ExecuteAction();
            }
        }
    }
}