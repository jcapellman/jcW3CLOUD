using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using jcW3CLOUD.PCL.Objects;
using jcW3CLOUD.PCL.ViewModels;
using jcW3CLOUD.UWP.PCL;

namespace jcW3CLOUD.UWP {
    public sealed partial class MainPage : Page {
        private MainModel viewModel => (MainModel) DataContext;

        public MainPage() {
            InitializeComponent();

            DataContext = new MainModel(new UWPControls(), new UWPPI());
            
            Unloaded += MainPage_Unloaded;
        }

        private void TxtBxURL_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args) {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput) {
                txtBxURL.ItemsSource = viewModel.BrowsingHistoryItems;
            }
        }

        private void TxtBxURL_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args) {
            viewModel.RequestAction = sender.Text;
        }

        private async void MainPage_Unloaded(object sender, RoutedEventArgs e) { await viewModel.Shutdown(); }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            var result = await viewModel.LoadData();

            icMain.Focus(FocusState.Programmatic);
        }
        
        public void mfiExit_OnClick(object sender, RoutedEventArgs e) {
            Application.Current.Exit();
        }

        private async void txtBxURL_SubmitSuggestion(AutoSuggestBox autoSuggestBox, AutoSuggestBoxQuerySubmittedEventArgs args) {
            viewModel.RequestAction = args.ChosenSuggestion != null ? ((BrowsingHistoryItem) args.ChosenSuggestion).URL : args.QueryText;

            icMain.Focus(FocusState.Programmatic);

            await viewModel.ExecuteAction();           
        }
    }
}