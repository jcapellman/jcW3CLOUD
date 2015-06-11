#ifndef __REQUESTRENDERER__
#define __REQUESTRENDERER__

#include "Main.h"
#include "NetworkHandler.h"
#include "ContentTypeParser.h"
#include "HtmlContentRenderer.h"
#include "JsonContentRenderer.h"
#include "XmlContentRenderer.h"
#include "PlainTextContentRenderer.h"

class RequestRenderer {
	public:
		RequestRenderer();

		bool Render(string request, WindowHandler &windowHandler, NetworkHandler &networkHandler);
};

#endif
