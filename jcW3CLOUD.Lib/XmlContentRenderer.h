#ifndef __XMLCONTENTRENDERER__
#define __XMLCONTENTRENDERER__

#include "Main.h"
#include "ContentRenderer.h"

class XmlContentRenderer : public ContentRenderer {
	public:
		XmlContentRenderer(WindowHandler * windowHandler) : ContentRenderer(windowHandler) { }

		virtual bool RenderContent(string content);
};

#endif
