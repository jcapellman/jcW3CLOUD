#include "Main.h"

#include "MotifWindowHandler.h"
#include "../jcW3CLOUD.Lib/MainWrapper.h"

int main(int argc, char* argv []) {
	Config cfg = Config();
	WindowHandler * wh;

	wh = new MotifWindowHandler;

	MainWrapper mainWrapper = MainWrapper(cfg, wh);
	mainWrapper.AIO();

	return 0;
}