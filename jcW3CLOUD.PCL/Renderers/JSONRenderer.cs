using System.Collections.Generic;

using jcW3CLOUD.PCL.Enums;

namespace jcW3CLOUD.PCL.Renderers {
    public class JSONRenderer : BaseRenderer {
        public override CONTENT_TYPES GetContentType() {
            return CONTENT_TYPES.JSON;
        }

        public override List<dynamic> RenderContent(string request) {
            var label = _baseControlImplementation.GetLabelControl();

            label.LabelContent = request;
            label.IsFullScreen = true;

            return new List<dynamic> {
                label.GetPlatformControl()
            };
        }

        public JSONRenderer(BaseControlImplementation bcImplementation) : base(bcImplementation) { }
    }
}