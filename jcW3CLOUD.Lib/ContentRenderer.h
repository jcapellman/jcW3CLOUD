#ifndef __CONTENTRENDERER__
#define __CONTENTRENDERER__

#include "Main.h"
#include "WindowHandler.h"

enum CONTENTRENDERERS {
	PLAIN_TEXT,
	XML,
	JSON,
	HTML
};

class ContentRenderer {
	public:
		ContentRenderer(WindowHandler &windowHandler);

		virtual bool RenderContent(string content) = 0;
};

#endif
