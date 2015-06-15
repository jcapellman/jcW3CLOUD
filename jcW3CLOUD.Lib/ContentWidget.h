#ifndef __CONTENTWIDGET__
#define __CONTENTWIDGET__

#include "Main.h"

struct ContentProperties {
	string content;

	int xPosition;
	int yPosition;
	int height;
	int width;
};

class ContentWidget {
	public:
		virtual bool CreateWidget(ContentProperties cProperties) = 0;
};

#endif
