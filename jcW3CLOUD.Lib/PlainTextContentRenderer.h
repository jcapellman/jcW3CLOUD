#ifndef __PLAINTEXTCONTENTRENDERER__
#define __PLAINTEXTCONTENTRENDERER__

#include "Main.h"
#include "ContentRenderer.h"

class PlainTextContentRenderer : public ContentRenderer {
	public:
		PlainTextContentRenderer(WindowHandler &windowHandler) : ContentRenderer(windowHandler) { }

		virtual bool RenderContent(string content);
};

#endif
