#include "RequestRenderer.h"

bool RequestRenderer::Render(string request, WindowHandler  * windowHandler, NetworkHandler &networkHandler) {
	ContentTypeParser ctParser;

	string requestContent = networkHandler.GetContent(request);

	CONTENTRENDERERS contentType = ctParser.GetContentRendererType(requestContent);

	if (contentType == HTML) {
		return false;
	}
	
	switch (contentType) {
		case HTML:
			return HtmlContentRenderer(windowHandler).RenderContent(requestContent);
		case JSON:
			return JsonContentRenderer(windowHandler).RenderContent(requestContent);
		case XML:
			return XmlContentRenderer(windowHandler).RenderContent(requestContent);
		case PLAIN_TEXT:
		default:
			return PlainTextContentRenderer(windowHandler).RenderContent(requestContent);
	}

	windowHandler = NULL;

	return false;
}
