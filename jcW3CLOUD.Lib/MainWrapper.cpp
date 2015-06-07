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

	this->_windowHandler->CreateWindow(xRes, yRes, bpp);

	return true;
}

void MainWrapper::AIO() {
	if (!this->Init()) {
		cout << "Could not initialize" << endl;
	}

	this->Run();

	this->Quit();
}