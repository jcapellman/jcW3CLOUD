#include "RequestRenderer.h"

bool RequestRenderer::Render(string request, WindowHandler  * windowHandler, NetworkHandler &networkHandler) {
	ContentTypeParser ctParser;

	string requestContent = networkHandler.GetContent(request);

	CONTENTRENDERERS contentType = ctParser.GetContentRendererType(requestContent);

	/*
	switch (contentType) {
		case HTML:
			return HtmlContentRenderer(windowHandler).RenderContent(requestContent);

			break;
		case JSON:
			return JsonContentRenderer(windowHandler).RenderContent(requestContent);
		case XML:
			return XmlContentRenderer(windowHandler).RenderContent(requestContent);
		case PLAIN_TEXT:
		default:
			return PlainTextContentRenderer(windowHandler).RenderContent(requestContent);
	}
*/
	return false;
}
