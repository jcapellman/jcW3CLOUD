#ifndef __FILEREADER__
#define __FILEREADER__

#include "Main.h"
#include "BookmarkItem.h"

class FileReader {
	public:
		vector<BookmarkItem> GetVector(string fileName, string delimiter);
		map<string, string> GetMap(string fileName, string delimiter);
};

#endif
