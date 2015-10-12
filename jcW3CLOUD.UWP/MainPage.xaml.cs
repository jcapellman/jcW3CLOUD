using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

using jcW3CLOUD.PCL.ViewModels;
using jcW3CLOUD.UWP.PCL;

namespace jcW3CLOUD.UWP {
    public sealed partial class MainPage : Page {
        private MainModel viewModel => (MainModel) DataContext;

        public MainPage() {
            InitializeComponent();

            DataContext = new MainModel(new UWPControls());
        }
        
        private async void txtBxURL_OnKeyDown(object sender, KeyRoutedEventArgs e) {
            if (e.Key == VirtualKey.Enter) {
                await viewModel.ExecuteAction();
            }
        }
    }
}