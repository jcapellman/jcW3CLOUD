#ifndef __HTMLCONTENTRENDERER__
#define __HTMLCONTENTRENDERER__

#include "Main.h"
#include "ContentRenderer.h"

class HtmlContentRenderer : public ContentRenderer {
public:
	HtmlContentRenderer(WindowHandler &windowHandler);

	bool RenderContent(string content);
};

#endif
