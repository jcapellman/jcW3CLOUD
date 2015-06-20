#include "Main.h"
#include "Config.h"
#include "WindowHandler.h"
#include "BookmarkManager.h"

class MainWrapper {
	public:
		MainWrapper(Config * cfg, WindowHandler * windowHandler);

		bool Init();

		void Run();
		void Quit();

		void AIO();
	private:
		Config * _config;
		WindowHandler * _windowHandler;
		BookmarkManager _bManager;
};