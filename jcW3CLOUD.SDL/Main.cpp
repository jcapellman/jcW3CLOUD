#include "Main.h"

#include "SDLWindowHandler.h"
#include "../jcW3CLOUD.Lib/MainWrapper.h"

int main(int argc, char* argv[]) {
	Config cfg = Config();
	SDLWindowHandler windowHandler = SDLWindowHandler();
	 
	MainWrapper mainWrapper = MainWrapper(cfg, windowHandler);
	mainWrapper.AIO();
	
	exit(0);
}