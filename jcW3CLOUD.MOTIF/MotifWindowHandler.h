#include "Main.h"
#include "../jcW3CLOUD.Lib/WindowHandler.h"

class MotifWindowHandler : public WindowHandler {
public:
	bool CreateWindow(int xRes, int yRes, int bpp);
	bool CloseWindow();
	bool EventPolling();
private:
	XtAppContext _appContext;
	Widget _wTopLevel;
};