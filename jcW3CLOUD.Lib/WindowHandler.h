#ifndef __WindowHandler__
#define __WindowHandler__

#include "Main.h"

class WindowHandler {
	public:
		virtual bool CreateWindow(int xRes, int yRes, int bpp) = 0;
		virtual bool CloseWindow() = 0;

		virtual bool CreateMenu() = 0;

		virtual bool EventPolling() = 0;
};

#endif