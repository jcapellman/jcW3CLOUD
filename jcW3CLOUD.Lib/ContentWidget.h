#ifndef __CONTENTWIDGET__
#define __CONTENTWIDGET__

#include "Main.h"
#include "WindowHandler.h"

class ContentWidget {
	public:
		virtual bool CreateWidget(WindowHandler &windowHandler, string content, float xPosition, float yPosition, float height, float width) = 0;
};

#endif
