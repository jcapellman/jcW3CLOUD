#include "Main.h"

#include "SDLWindowHandler.h"

#include "../jcW3CLOUD.Lib/Config.h"

int main(int argc, char* argv[]) {
	Config cfg = Config("config.cfg");

	int xRes = cfg.GetIntConfig(CONFIG_KEYS::xres);
	int yRes = cfg.GetIntConfig(CONFIG_KEYS::yres);
	int bpp = cfg.GetIntConfig(CONFIG_KEYS::bpp);

	SDLWindowHandler windowHandler = SDLWindowHandler();

	windowHandler.CreateWindow(xRes, yRes, bpp);
	windowHandler.EventPolling();
	windowHandler.CloseWindow();

	exit(0);
}