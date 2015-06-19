#ifndef __WINDOWHANDLER__
#define __WINDOWHANDLER__

#include "Main.h"
#include "ContentWidget.h"

class WindowHandler {
public:
	virtual bool CreateWindow(int xRes, int yRes, int bpp) = 0;
	virtual bool CloseWindow() = 0;

	virtual bool CreateMenu() = 0;

	virtual bool EventPolling() = 0;

	virtual bool AddWidget(ContentWidget &widget) = 0;
};

#endif