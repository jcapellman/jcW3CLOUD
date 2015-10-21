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
            _controlImplemntation = controlImplementation;
            _platformImplementation = platformImplementation;
        }

        private bool _SETTING_enableHistory;

        public bool SETTING_enableHistory {
            get {  return _SETTING_enableHistory; }
            set { _SETTING_enableHistory = value; OnPropertyChanged(); }
        }

        private bool _SETTING_encryptAllFiles;

        public bool SETTING_encryptAllFiles {
            get { return _SETTING_encryptAllFiles; }
            set { _SETTING_encryptAllFiles = value; OnPropertyChanged(); }
        }

        public void LoadSettings() {
            SETTING_enableHistory = _platformImplementation.GetSettings().GetSetting<bool>(SETTINGS.ENABLE_HISTORY);
            SETTING_encryptAllFiles = _platformImplementation.GetSettings().GetSetting<bool>(SETTINGS.ENCRYPT_ALL_FILES);
        }

        public void SaveSettings() {
            _platformImplementation.GetSettings().WriteSetting(SETTINGS.ENABLE_HISTORY, SETTING_enableHistory);
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
        
        private async Task<HttpResponseMessage> GetContent(string request) {
            using (var httpClient = new HttpClient()) {
                var message = new HttpRequestMessage(HttpMethod.Get, request);
                message.Headers.Add("User-Agent", "jcW3CLOUD");

                return await httpClient.SendAsync(message);
            }
        }

        private void SanitizeRequestString() {
            if (!RequestAction.ToUpper().StartsWith("HTTP://")) {
                RequestAction = "http://" + RequestAction;
            }
        }

        private CONTENT_TYPES parseResponse(HttpResponseMessage response, ref string errorString) {
            if (!response.IsSuccessStatusCode) {
                errorString = response.StatusCode.ToString();
                return CONTENT_TYPES.TEXT;
            }

            if (response.Content.Headers.ContentType.MediaType == "text/plain") {
                return CONTENT_TYPES.TEXT;
            }

            return CONTENT_TYPES.TEXT;
        }

        public async Task<bool> ExecuteAction() {
            IsWorking = true;

            SanitizeRequestString();

            var response = await GetContent(RequestAction);

            var errorString = string.Empty;

            var renderer = GetRenderer(parseResponse(response, ref errorString));

            string content;

            if (!string.IsNullOrEmpty(errorString)) {
                content = errorString;
            } else {
                content = await response.Content.ReadAsStringAsync();
            }

            ContentControls = new ObservableCollection<dynamic>(renderer.RenderContent(content));
 
            IsWorking = false;

            if (!SETTING_enableHistory) {
                return true;
            }

            if (BrowsingHistoryItems.All(a => a.URL != RequestAction)) {
                BrowsingHistoryItems.Add(new BrowsingHistoryItem { URL = RequestAction });

                await Shutdown();
            }
            
            return true;
        }
    }
}