#include "Main.h"
#include "Config.h"
#include "WindowHandler.h"

class MainWrapper {
	public:
		MainWrapper(Config cfg, WindowHandler &windowHandler);

		bool Init();

		void Run();
		void Quit();
	private:
		Config _config;
		WindowHandler * _windowHandler;
};