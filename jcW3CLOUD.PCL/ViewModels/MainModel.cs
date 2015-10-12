using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using jcW3CLOUD.PCL.Enums;
using jcW3CLOUD.PCL.Renderers;

namespace jcW3CLOUD.PCL.ViewModels {
    public class MainModel : BaseModel {
        private ObservableCollection<dynamic> _contentControls;
         
        public ObservableCollection<dynamic> ContentControls {
            get { return _contentControls; }

            set { _contentControls = value; OnPropertyChanged(); }
        }

        private string _requestAction;

        private readonly BaseControlImplementation _controlImplemntation;

        public MainModel(BaseControlImplementation controlImplementation) {
            IsWorking = false;

            _controlImplemntation = controlImplementation;
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

            return true;
        }
    }
}