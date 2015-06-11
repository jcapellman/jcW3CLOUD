#ifndef __BUTTONWIDGET__
#define __BUTTONWIDGET__

#include "Main.h"
#include "../jcW3CLOUD.Lib/ContentWidget.h"

class ButtonWidget : public ContentWidget {
public:
	ButtonWidget() { }

	bool CreateWidget(WindowHandler &windowHandler, string content, float xPosition, float yPosition, float height, float width) {
		return windowHandler.AddWidget(NULL);
	}
};

#endif
