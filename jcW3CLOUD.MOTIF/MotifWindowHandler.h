#include "Main.h"
#include "../jcW3CLOUD.Lib/WindowHandler.h"

class MotifWindowHandler : public WindowHandler {
	public:
		virtual bool CreateWindow(int xRes, int yRes, int bpp);
		virtual bool CloseWindow();
		virtual bool EventPolling();
		virtual bool CreateMenu();
		virtual bool AddWidget(ContentWidget &widget);
	private:
		XtAppContext _appContext;
		Widget _wTopLevel;
};