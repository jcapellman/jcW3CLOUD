#include "Main.h"

#include "MotifWindowHandler.h"
#include "../jcW3CLOUD.Lib/MainWrapper.h"

int main(int argc, char* argv []) {
	Config cfg("config.cfg");
	WindowHandler * wh;

	wh = new MotifWindowHandler;

	MainWrapper mainWrapper(&cfg, wh);
	mainWrapper.AIO();

	return 0;
}