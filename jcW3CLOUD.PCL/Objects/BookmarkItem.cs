using System.Runtime.Serialization;

namespace jcW3CLOUD.PCL.Objects {
    [DataContract]
    public class BookmarkItem {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string URL { get; set; }
    }
}