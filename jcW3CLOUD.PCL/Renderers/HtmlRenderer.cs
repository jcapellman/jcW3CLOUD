using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using jcW3CLOUD.PCL.Enums;

namespace jcW3CLOUD.PCL.Renderers {
    public class HtmlRenderer : BaseRenderer {
        public HtmlRenderer(BaseControlImplementation bcImplementation) : base(bcImplementation) { }

        public override CONTENT_TYPES GetContentType() {
            return CONTENT_TYPES.HTML;
        }

        private List<dynamic> getBlankPage() {
            var label = _baseControlImplementation.GetLabelControl();

            label.LabelContent = string.Empty;
            label.IsFullScreen = true;

            return new List<dynamic> {
                label.GetPlatformControl()
            };
        }

        private dynamic createNewLabel(string content) {
            var label = _baseControlImplementation.GetLabelControl();

            label.LabelContent = content;
            label.IsFullScreen = false;

            return label;
        }

        public override List<dynamic> RenderContent(string request) {
            var bodyStart = request.ToUpper().IndexOf("<BODY>");

            if (bodyStart == -1) {
                return getBlankPage();
            }

            var content = new List<dynamic>();

            foreach (var splitItem in request.Substring(bodyStart).Split('<'))
            {
                var endTagIdx = splitItem.IndexOf('>');

                var tag = splitItem.Substring(0, endTagIdx);

                var tagName = tag.Split(' ')[0].ToUpper();

                switch (tagName)
                {
                    case "P":
                        content.Add(createNewLabel(tagName));
                        break;
                    case "INPUT":
                        break;
                    case "A":
                        break;
                }
            }

            return content;
        }
    }
}