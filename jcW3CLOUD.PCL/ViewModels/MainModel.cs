using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

using jcW3CLOUD.PCL.Enums;
using jcW3CLOUD.PCL.Objects;
using jcW3CLOUD.PCL.Renderers;
using jcW3CLOUD.PCL.Wrappers;

namespace jcW3CLOUD.PCL.ViewModels {
    public class MainModel : BaseModel {

        private ObservableCollection<dynamic> _contentControls;
         
        public ObservableCollection<dynamic> ContentControls {
            get { return _contentControls; }

            set { _contentControls = value; OnPropertyChanged(); }
        }

        private string _requestAction;

        private readonly BaseControlImplementation _controlImplemntation;
        private readonly BasePlatformImplementation _platformImplementation;

        private ObservableCollection<BrowsingHistoryItem> _browsingHistoryItems;

        public ObservableCollection<BrowsingHistoryItem> BrowsingHistoryItems {
            get {  return _browsingHistoryItems; }
            set { _browsingHistoryItems = value; OnPropertyChanged(); }
        }

        public MainModel(BaseControlImplementation controlImplementation, BasePlatformImplementation platformImplementation) {
            IsWorking = false;

            _controlImplemntation = controlImplementation;
            _platformImplementation = platformImplementation;
        }

        public async Task<bool> LoadData() {
            try {
                var fs = _platformImplementation.GetFileSystem();

                var result = await fs.GetFile<BrowsingHistoryWrapper>(FILE_TYPES.BROWSING_HISTORY);

                if (result == null || result.HasError) {
                    BrowsingHistoryItems = new ObservableCollection<BrowsingHistoryItem>();
                    return true;
                }

                BrowsingHistoryItems = new ObservableCollection<BrowsingHistoryItem>(result.Value.History);

                return true;
            } catch (Exception ex) {

                return false;
            }
        }

        public string RequestAction {  get { return _requestAction; } set { _requestAction = value; OnPropertyChanged(); } }

        private BaseRenderer GetRenderer(CONTENT_TYPES contentType) {
            var types = GetType().GetTypeInfo().Assembly.DefinedTypes;

            foreach (var type in types) {
                if (type.IsSubclassOf(typeof(BaseRenderer)) && !type.IsAbstract) {
                    var renderer = (BaseRenderer)Activator.CreateInstance(type.AsType(), _controlImplemntation);

                    if (renderer.GetContentType() == contentType) {
                        return renderer;
                    }
                }
            }

            return null;
        }

        public async Task<CTO<bool>> Shutdown() {
            var fs = _platformImplementation.GetFileSystem();

            return await fs.WriteFile(FILE_TYPES.BROWSING_HISTORY, new BrowsingHistoryWrapper { History = BrowsingHistoryItems.ToList()});
        }

        private async Task<string> GetContent(string request) {
            using (var httpClient = new HttpClient()) {
                return await httpClient.GetStringAsync(request);
            }
        }

        public async Task<bool> ExecuteAction() {
            IsWorking = true;

            var content = await GetContent(RequestAction);

            if (RequestAction.EndsWith(".txt")) {
                var renderer = GetRenderer(CONTENT_TYPES.TEXT);

                ContentControls = new ObservableCollection<dynamic>(renderer.RenderContent(content));
            }

            IsWorking = false;

            BrowsingHistoryItems.Add(new BrowsingHistoryItem {URL = RequestAction});

            await Shutdown();

            return true;
        }
    }
}