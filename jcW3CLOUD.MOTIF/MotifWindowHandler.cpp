#include "MotifWindowHandler.h"

bool MotifWindowHandler::AddWidget(ContentWidget &widget) {
	return true;
}

bool MotifWindowHandler::CreateWindow(int xRes, int yRes, int bpp) {
	this->_wTopLevel = XtVaAppInitialize(
		&this->_appContext,
		WINDOW_TITLE,
		NULL, 0,
		NULL, 
		NULL,
		NULL,
		NULL);

	XtRealizeWidget(this->_wTopLevel);

	return true;
}

bool MotifWindowHandler::CreateMenu() {
	Widget main_w = XtVaCreateManagedWidget("main_window",
		xmMainWindowWidgetClass, this->_wTopLevel,
		NULL);

	Widget wMenuBar = XmCreateMenuBar(main_w, "main_list",
		NULL, 0);

	XtManageChild(wMenuBar);

	Widget wHelp = XtVaCreateManagedWidget("Help",
		xmCascadeButtonWidgetClass, wMenuBar,
		XmNmnemonic, 'H',
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