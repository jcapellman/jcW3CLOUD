#ifndef __NETWORKHANDLER__
#define __NETWORKHANDLER__

#include "Main.h"

class NetworkHandler {
	public:
		virtual string GetContent(string url) = 0;
};

#endif