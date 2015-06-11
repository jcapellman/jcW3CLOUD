#ifndef __JSONCONTENTRENDERER__
#define __JSONCONTENTRENDERER__

#include "Main.h"
#include "ContentRenderer.h"

class JsonContentRenderer : public ContentRenderer {
	public:
		JsonContentRenderer(WindowHandler &windowHandler);

		bool RenderContent(string content);
};

#endif
