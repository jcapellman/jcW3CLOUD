#include "SDLWindowHandler.h"

bool SDLWindowHandler::CreateWindow(int xRes, int yRes, int bpp) {
	SDL_Init(SDL_INIT_VIDEO);

	screen = SDL_SetVideoMode(xRes, yRes, bpp, SDL_HWSURFACE);
	SDL_WM_SetCaption(WINDOW_TITLE, NULL);

	return true;
}

bool SDLWindowHandler::CloseWindow() {
	SDL_Quit();

	return true;
}

bool SDLWindowHandler::CreateMenu() {
	return true;
}

bool SDLWindowHandler::EventPolling() {
	bool quit = false;

	while (quit == false) {
		if (SDL_PollEvent(&event)) {
			if (event.type == SDL_QUIT) {
				quit = true;
			}
		}

		SDL_Flip(screen);
	}

	return true;
}