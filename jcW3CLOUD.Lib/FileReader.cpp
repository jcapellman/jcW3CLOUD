#include "FileReader.h"

vector<BookmarkItem> FileReader::GetVector(string fileName, string delimiter) {
	std::ifstream iConfig(fileName, std::ifstream::in);
	string line;
	vector<BookmarkItem> tmpVector;
	vector<BookmarkItem>::iterator it;

	it = tmpVector.begin();

	if (!iConfig.is_open()) {
		return tmpVector;
	}

	while (getline(iConfig, line)) {
		string description;
		string url;

		int positionIdx = line.find("||");

		if (positionIdx == string::npos) {
			continue;
		}

		description = line.substr(0, positionIdx);

		url = line.substr(positionIdx, line.length() - positionIdx);

		tmpVector.insert(it, description, url);
	}

	iConfig.close();

	return tmpVector;
}

map<string, string> FileReader::GetMap(string fileName, string delimiter) {
	std::ifstream iConfig(fileName, std::ifstream::in);
	string line;
	map<string, string> tmpMap;

	if (!iConfig.is_open()) {
		return tmpMap;
	}

	while (getline(iConfig, line)) {
		string value;
		string key;

		int positionIdx = line.find(delimiter);

		if (positionIdx == string::npos) {
			continue;
		}

		key = line.substr(0, positionIdx);

		value = line.substr(positionIdx, line.length() - positionIdx);

		tmpMap[key] = value;
	}

	iConfig.close();

	return tmpMap;
}