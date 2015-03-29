using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Windows;

namespace jcW3CLOUD {    
    public class JCW3CLOUD : IJCW3CLOUD {
        public JCW3CLOUDPage renderPage(string URL) {
            using (WebClient wc = new WebClient()) {
                JCW3CLOUDPage page = new JCW3CLOUDPage();

                if (!URL.StartsWith("http://")) {
                    URL = "http://" + URL;
                }

                
                page.HTML = wc.DownloadString(URL);

                return page;
            }
        }
    }
}
