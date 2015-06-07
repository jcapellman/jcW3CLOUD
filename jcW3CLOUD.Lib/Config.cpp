#include "Config.h"

Config::Config() : Config(DEFAULT_CONFIG_FILENAME) { }

Config::Config(char * fileName) {
	readConfig(fileName);
}

void Config::readConfig(char * fileName) {
	std::ifstream iConfig(fileName, std::ifstream::in);
	string line;

	if (!iConfig.is_open()) {
		return;
	}

	while (getline(iConfig, line)) {
		string value;
		string key;

		int positionIdx = line.find(" ");

		if (positionIdx == string::npos) {
			continue;
		}

		key = line.substr(0, positionIdx);
		
		value = line.substr(positionIdx, line.length() - positionIdx);

		this->_mConfig[key] = value;
	}

	iConfig.close();
}

int Config::GetIntConfig(string key) {
	string value = this->GetStringConfig(key);

	if (value == "") {
		return 0;
	}

	return atoi(value.c_str());
}

string Config::GetStringConfig(string key) {
	auto pos = this->_mConfig.find(key);

	if (pos == this->_mConfig.end()) {
		return "";
	}

	return pos->second;
}