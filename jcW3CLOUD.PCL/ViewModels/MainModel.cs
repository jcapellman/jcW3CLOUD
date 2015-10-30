using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

using jcW3CLOUD.PCL.Enums;
using jcW3CLOUD.PCL.Objects;
using jcW3CLOUD.PCL.PlatformAbstractions;
using jcW3CLOUD.PCL.Renderers;
using jcW3CLOUD.PCL.Wrappers;

namespace jcW3CLOUD.PCL.ViewModels {
    public class MainModel : BaseModel {
      
        private string _versionString;

        public string VersionString {  get { return _versionString; } set { _versionString = value; OnPropertyChanged(); } }

        private string _settingefaultHomePage;

        public string SETTING_DefaultHomePage {
            get { return _settingefaultHomePage; }
            set { _settingefaultHomePage = value; OnPropertyChanged(); }
        }

        private ObservableCollection<dynamic> _contentControls;
         
        public ObservableCollection<dynamic> ContentControls {
            get { return _contentControls; }

            set { _contentControls = value; OnPropertyChanged(); }
        }

        private string _addBookmarkDescription;

        public string AddBookmarkDescription {
            get { return _addBookmarkDescription; }
            set {
                _addBookmarkDescription = value; OnPropertyChanged();
                AddBookmarkEnabled = !string.IsNullOrEmpty(_addBookmarkURL) &&
                                     !string.IsNullOrEmpty(_addBookmarkDescription);
            }
        }

        private string _addBookmarkURL;

        public string AddBookmarkURL {
            get { return _addBookmarkURL; }
            set {
                _addBookmarkURL = value; OnPropertyChanged();
                AddBookmarkEnabled = !string.IsNullOrEmpty(_addBookmarkURL) &&
                                     !string.IsNullOrEmpty(_addBookmarkDescription);
            }
        }

        private bool _addBookmarkEnabled;

        public bool AddBookmarkEnabled {
            get { return _addBookmarkEnabled; }
            set { _addBookmarkEnabled = value; OnPropertyChanged(); }
        }

        private string _requestAction;

        private readonly BaseControlImplementation _controlImplemntation;
        private readonly BasePlatformImplementation _platformImplementation;

        private ObservableCollection<BookmarkItem> _bookmarkItems;

        public ObservableCollection<BookmarkItem> BookmarkItems {
            get { return _bookmarkItems; }
            set { _bookmarkItems = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BrowsingHistoryItem> _browsingHistoryItems;

        public ObservableCollection<BrowsingHistoryItem> BrowsingHistoryItems {
            get {  return _browsingHistoryItems; }
            set { _browsingHistoryItems = value; OnPropertyChanged(); }
        }

        public MainModel(BaseControlImplementation controlImplementation, BasePlatformImplementation platformImplementation) {
            _controlImplemntation = controlImplementation;
            _platformImplementation = platformImplementation;

            _platformImplementation.GetNetwork().NetworkChanged += MainModel_NetworkChanged;
            
            _platformImplementation.GetNetwork().PlatformCheck();

            VersionString = Common.Constants.VERSION;
        }

        private bool _isConnected;

        private void MainModel_NetworkChanged(object sender, NetworkEventArgs e) {
            _isConnected = e.IsConnnected;
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
            SETTING_DefaultHomePage = _platformImplementation.GetSettings().GetSetting<string>(SETTINGS.DEFAULT_HOME_PAGE);
        }

        public void SaveSettings() {
            _platformImplementation.GetSettings().WriteSetting(SETTINGS.ENABLE_HISTORY, SETTING_enableHistory);
            _platformImplementation.GetSettings().WriteSetting(SETTINGS.ENCRYPT_ALL_FILES, SETTING_encryptAllFiles);
            _platformImplementation.GetSettings().WriteSetting(SETTINGS.DEFAULT_HOME_PAGE, SETTING_DefaultHomePage);
        }

        public async Task<CTO<bool>> LoadData() {
            try {
                var fs = _platformImplementation.GetFileSystem();

                var result = await fs.GetFile<BrowsingHistoryWrapper>(FILE_TYPES.BROWSING_HISTORY);

                if (result == null || result.HasError) {
                    BrowsingHistoryItems = new ObservableCollection<BrowsingHistoryItem>();
                } else {                
                    BrowsingHistoryItems = new ObservableCollection<BrowsingHistoryItem>(result.Value.History);
                }

                var bookmarks = await fs.GetFile<BookmarkWrapper>(FILE_TYPES.BOOKMARKS);

                if (bookmarks == null || bookmarks.HasError) {
                    BookmarkItems = new ObservableCollection<BookmarkItem>();
                } else {
                    BookmarkItems = new ObservableCollection<BookmarkItem>(bookmarks.Value.Bookmarks);
                }

                LoadSettings();

                if (string.IsNullOrEmpty(SETTING_DefaultHomePage)) {
                    return new CTO<bool>(true);
                }

                RequestAction = SETTING_DefaultHomePage;

                return await ExecuteAction();
            } catch (Exception ex) {
                return new CTO<bool>(false, ex.ToString());
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

            await fs.WriteFile(FILE_TYPES.BROWSING_HISTORY, new BrowsingHistoryWrapper { History = BrowsingHistoryItems.ToList()});

            await fs.WriteFile(FILE_TYPES.BOOKMARKS, new BookmarkWrapper { Bookmarks = BookmarkItems.ToList() });

            return new CTO<bool>(true);
        }

        private async Task<HttpResponseMessage> getLocalContent(string request) {
            var content = await _platformImplementation.GetFileSystem().GetLocalFile(request);

            if (string.IsNullOrEmpty(content)) {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            var message = new HttpResponseMessage(HttpStatusCode.OK);

            message.Content = new StringContent(content);

            return message;
        }
        
        private async Task<HttpResponseMessage> GetContent(string request) {
            if (isRequestLocal) {
                return await getLocalContent(request);
            }

            using (var httpClient = new HttpClient()) {
                var message = new HttpRequestMessage(HttpMethod.Get, request);
                message.Headers.Add("User-Agent", $"jcW3CLOUD {_versionString}");

                return await httpClient.SendAsync(message);
            }
        }

        private void SanitizeRequestString() {
            if (!isRequestLocal && !RequestAction.ToUpper().StartsWith("HTTP://")) {
                RequestAction = "http://" + RequestAction;
            }
        }

        private CONTENT_TYPES parseResponse(HttpResponseMessage response, ref string errorString) {
            if (!response.IsSuccessStatusCode) {
                errorString = response.StatusCode.ToString();

                return CONTENT_TYPES.TEXT;
            }

            switch (response.Content.Headers.ContentType.MediaType) {
                case "text/plain":
                    return CONTENT_TYPES.TEXT;
                case "text/html":
                    return CONTENT_TYPES.HTML;
                case "text/json":
                    return CONTENT_TYPES.JSON;
                default:
                    return CONTENT_TYPES.TEXT;
            }
        }

        public async Task<CTO<bool>> AddBookmark() {
            BookmarkItems.Add(new BookmarkItem {URL = AddBookmarkURL, Description = AddBookmarkDescription});

            var fs = _platformImplementation.GetFileSystem();

            return await fs.WriteFile(FILE_TYPES.BOOKMARKS, new BookmarkWrapper { Bookmarks = BookmarkItems.ToList() });
        }

        private bool isRequestLocal => RequestAction.ToUpper().StartsWith("C:");

        public async Task<CTO<bool>> ExecuteAction() {
            IsWorking = true;

            if (!_isConnected && !isRequestLocal) {
                return new CTO<bool>(false, "Not Connected to a Network");
            }

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
                return new CTO<bool>(true);
            }

            if (BrowsingHistoryItems.All(a => a.URL != RequestAction)) {
                BrowsingHistoryItems.Add(new BrowsingHistoryItem { URL = RequestAction });

                await Shutdown();
            }
            
            return new CTO<bool>(true);
        }

        public async Task<CTO<bool>>  ExecuteLocalRequest(string path, string content) {
            IsWorking = true;

            RequestAction = path;

            var response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new StringContent(content);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            
            var errorString = string.Empty;

            var renderer = GetRenderer(parseResponse(response, ref errorString));
            
            ContentControls = new ObservableCollection<dynamic>(renderer.RenderContent(content));

            IsWorking = false;

            if (!SETTING_enableHistory) {
                return new CTO<bool>(true);
            }

            if (BrowsingHistoryItems.All(a => a.URL != RequestAction)) {
                BrowsingHistoryItems.Add(new BrowsingHistoryItem { URL = RequestAction });

                await Shutdown();
            }

            return new CTO<bool>(true);
        }
    }
}