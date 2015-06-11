#include "PlainTextContentRenderer.h"

PlainTextContentRenderer::PlainTextContentRenderer(WindowHandler &windowHandler) : ContentRenderer(windowHandler) {
}

bool PlainTextContentRenderer::RenderContent(string content) {
	return true;
}
