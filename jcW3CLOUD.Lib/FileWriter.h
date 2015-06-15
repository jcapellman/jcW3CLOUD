#ifndef __FILEWRITER__
#define __FILEWRITER__

#include "Main.h"
#include "BookmarkItem.h"

class FileWriter {
	public:
		bool WriteFile(string fileName, vector<string> data);
};

#endif
