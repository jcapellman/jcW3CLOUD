#ifndef __FILEWRITER__
#define __FILEWRITER__

#include "Main.h"
#include "BookmarkItem.h"

class FileWriter {
	public:
		template <class T>
		bool WriteFile(string fileName, vector<T, std::allocator<T>>);
};

#endif
