#ifndef __HTMLCONTENTRENDERER__
#define __HTMLCONTENTRENDERER__

#include "Main.h"
#include "ContentRenderer.h"

class HtmlContentRenderer : public ContentRenderer {
public:
	HtmlContentRenderer(WindowHandler &windowHandler) : ContentRenderer(windowHandler) { }

	virtual bool RenderContent(string content);
};

#endif
