#include "Main.h"

#include "SDLWindowHandler.h"
#include "../jcW3CLOUD.Lib/MainWrapper.h"

int main(int argc, char* argv[]) {
	Config cfg = Config("config.cfg");

	SDLWindowHandler windowHandler = SDLWindowHandler();

	MainWrapper mainWrapper = MainWrapper(cfg, windowHandler);

	mainWrapper.Init();
	mainWrapper.Run();
	mainWrapper.Quit();
	
	exit(0);
}