#include "Main.h"

#include "MotifWindowHandler.h"
#include "../jcW3CLOUD.Lib/MainWrapper.h"

int main(int argc, char* argv []) {
	Config cfg = Config();
	MotifWindowHandler windowHandler = MotifWindowHandler();

	MainWrapper mainWrapper = MainWrapper(cfg, windowHandler);
	mainWrapper.AIO();

	exit(0);
}