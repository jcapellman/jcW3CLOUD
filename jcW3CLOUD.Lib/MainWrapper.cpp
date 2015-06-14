#include "MainWrapper.h"

MainWrapper::MainWrapper(Config cfg, WindowHandler &windowHandler) {
	this->_config = cfg;
	this->_windowHandler = &windowHandler;
}

void MainWrapper::Run() {
	this->_windowHandler->EventPolling();
}

void MainWrapper::Quit() {
	this->_windowHandler->CloseWindow();
}

bool MainWrapper::Init() {
	int xRes = this->_config.GetIntConfig(CONFIG_KEYS::xres);
	int yRes = this->_config.GetIntConfig(CONFIG_KEYS::yres);
	int bpp = this->_config.GetIntConfig(CONFIG_KEYS::bpp);

	string bookmarkFilename = this->_config.GetStringConfig(CONFIG_KEYS::bookmark_filename);

	if (bookmarkFilename.length() == 0) {
		bookmarkFilename = DEFAULT_BOOKMARK_FILENAME;
	}

	this->_bManager = BookmarkManager(bookmarkFilename);

	this->_windowHandler->CreateWindow(xRes, yRes, bpp);

	this->_windowHandler->CreateMenu();

	return true;
}

void MainWrapper::AIO() {
	if (!this->Init()) {
		cout << "Could not initialize" << endl;
	}

	this->Run();

	this->Quit();
}