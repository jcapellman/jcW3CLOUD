using System.Collections.Generic;

using jcW3CLOUD.PCL.BaseControls;
using jcW3CLOUD.PCL.Enums;

namespace jcW3CLOUD.PCL.Renderers {
    public abstract  class BaseRenderer {
        public abstract CONTENT_TYPES GetContentType();

        public abstract List<dynamic> RenderContent(string request);

        internal BaseControlImplementation _baseControlImplementation;

        protected BaseRenderer(BaseControlImplementation bcImplementation) {
            _baseControlImplementation = bcImplementation;
        }
    }
}