using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace jcW3CLOUD.PCL.ViewModels {
    public class BaseModel : INotifyPropertyChanged {
        private bool _isWorking;

        public bool IsWorking {
            get {  return _isWorking; }

            set { _isWorking = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}