#include "FileWriter.h"

bool FileWriter::WriteFile(string fileName, vector<string> data) {
	ofstream oFile(fileName);

	if (!oFile.is_open()) {
		return false;
	}

	for (unsigned int x = 0; x < data.size(); x++) {
		oFile << data.at(x);
	}

	oFile.close();
}
