#include "Main.h"

#include "SDLWindowHandler.h"

#include "../jcW3CLOUD.Lib/Config.h"

int main(int argc, char* argv[]) {
	Config cfg = Config("config.cfg");

	int xRes = cfg.GetIntConfig("xres");
	int yRes = cfg.GetIntConfig("yres");
	int bpp = cfg.GetIntConfig("bpp");

	SDLWindowHandler windowHandler = SDLWindowHandler();

	windowHandler.CreateWindow(xRes, yRes, bpp);
	windowHandler.EventPolling();
	windowHandler.CloseWindow();

	exit(0);
}