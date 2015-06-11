#include "RequestRenderer.h"

bool RequestRenderer::Render(string request, WindowHandler &windowHandler, NetworkHandler &networkHandler) {
	ContentTypeParser ctParser = ContentTypeParser();

	string requestContent = networkHandler.GetContent(request);

	CONTENTRENDERERS contentType = ctParser.GetContentRendererType(requestContent);

	
	switch (contentType) {
		case HTML:
			HtmlContentRenderer htmlRenderer = HtmlContentRenderer(windowHandler);

			return htmlRenderer.RenderContent(requestContent);
		case JSON:
			JsonContentRenderer jsonRenderer = JsonContentRenderer(windowHandler);

			return jsonRenderer.RenderContent(requestContent);
		case XML:
			XmlContentRenderer xmlRenderer = XmlContentRenderer(windowHandler);

			return xmlRenderer.RenderContent(requestContent);
		case PLAIN_TEXT:
		default:
			PlainTextContentRenderer plainRenderer = PlainTextContentRenderer(windowHandler);

			return plainRenderer.RenderContent(requestContent);
	}

	return false;
}
