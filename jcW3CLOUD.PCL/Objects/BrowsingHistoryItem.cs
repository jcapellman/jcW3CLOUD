using System.Runtime.Serialization;

namespace jcW3CLOUD.PCL.Objects {
    [DataContract]
    public class BrowsingHistoryItem {
        [DataMember]
        public string URL { get; set; }
    }
}