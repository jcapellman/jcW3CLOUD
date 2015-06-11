#include "Main.h"
#include "../jcW3CLOUD.Lib/WindowHandler.h"

class SDLWindowHandler : public WindowHandler {
	public:
		bool CreateWindow(int xRes, int yRes, int bpp);
		bool CloseWindow();
		bool EventPolling();
		bool CreateMenu();
	private:
		SDL_Surface * screen;
		SDL_Event event;
};