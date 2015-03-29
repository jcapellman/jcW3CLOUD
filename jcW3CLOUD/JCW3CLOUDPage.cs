using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace jcW3CLOUD {
    [DataContract]
    public class JCW3CLOUDPage {
        public byte[] Data {get; set;}

        public JCW3CLOUDPage() {
        }
    }
}