using System.Collections.Generic;

using jcW3CLOUD.PCL.BaseControls;
using jcW3CLOUD.PCL.Enums;

namespace jcW3CLOUD.PCL.Renderers {
    public class TextRenderer : BaseRenderer {
        public override CONTENT_TYPES GetContentType() {
            return CONTENT_TYPES.TEXT;
        }

        public TextRenderer(BaseControlImplementation baseControlImplementation) : base(baseControlImplementation) { }

        public override List<dynamic> RenderContent(string request) {
            var label = _baseControlImplementation.GetLabelControl();

            label.LabelContent = request;
            label.IsFullScreen = true;
           
            return new List<dynamic> {
                label.GetPlatformControl()
            };
        }
    }
}