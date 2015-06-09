#ifndef __NETWORKHANDLER__
#define __NETWORKHANDLER__

#include "Main.h"

class NetworkHandler {
	public:
		virtual vector<unsigned char> GetPage(string url) = 0;
};

#endif