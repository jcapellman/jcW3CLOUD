#include "MotifWindowHandler.h"

bool MotifWindowHandler::CreateWindow(int xRes, int yRes, int bpp) {
	this->_wTopLevel = XtVaAppInitialize(
		&this->_appContext,
		WINDOW_TITLE,
		NULL, 0,
		NULL, 
		NULL,
		NULL,
		NULL);

	return true;
}

bool MotifWindowHandler::CloseWindow() {
	return true;
}

bool MotifWindowHandler::EventPolling() {
	XtAppMainLoop(this->_appContext);

	return true;
}