#ifndef __FILEWRITER__
#define __FILEWRITER__

#include "Main.h"

template<class T>
class FileWriter {
	public:
		template<class T> bool WriteFile(string fileName, vector<T> data);
};

#endif
