#ifndef __CONTENTTYPEPARSER__
#define __CONTENTTYPEPARSER__

#include "Main.h"
#include "ContentRenderer.h"

class ContentTypeParser {
	public:
		ContentTypeParser();

		CONTENTRENDERERS GetContentRendererType(string content);
};

#endif
