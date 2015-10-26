using System.Collections.Generic;
using System.Runtime.Serialization;

using jcW3CLOUD.PCL.Objects;

namespace jcW3CLOUD.PCL.Wrappers {
    [DataContract]
    public class BookmarkWrapper {
        [DataMember]
        public List<BookmarkItem> Bookmarks { get; set; } 
    }
}