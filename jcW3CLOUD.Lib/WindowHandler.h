#include "Main.h"

class WindowHandler {
	virtual bool CreateWindow(int xRes, int yRes, int bpp) = 0;
	virtual bool CloseWindow() = 0;

	virtual bool EventPolling() = 0;
};