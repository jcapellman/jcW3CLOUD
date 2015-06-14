#include "FileWriter.h"

template<class T> bool FileWriter::WriteFile(string fileName, vector<T> data) {
	std::ofstream oFile(fileName, std::ofstream::out);

	if (!oFile.open()) {
		return false;
	}

	for (int x = 0; x < data.size(); x++) {
		oFile << data.at(x);
	}

	oFile.close();
}
